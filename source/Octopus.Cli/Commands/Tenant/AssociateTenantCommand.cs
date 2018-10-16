using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Octopus.Cli.Infrastructure;
using Octopus.Cli.Repositories;
using Octopus.Cli.Util;
using Octopus.Client;
using Octopus.Client.Model;

namespace Octopus.Cli.Commands.Tenant
{
    [Command("associate-tenant", Description = "Associate a tenant with a project and environment")]
    class AssociateTenantCommand : ApiCommand, ISupportFormattedOutput
    {
        private TenantResource tenant;

        public string TenantName { get; set; }
        public string ProjectName { get; set; }
        public string EnvironmentName { get; set; }

        public AssociateTenantCommand(IOctopusClientFactory clientFactory, IOctopusAsyncRepositoryFactory repositoryFactory, IOctopusFileSystem fileSystem, ICommandOutputProvider commandOutputProvider) : base(clientFactory, repositoryFactory, fileSystem, commandOutputProvider)
        {
            var options = Options.For("Association");
            options.Add("project=", "Name of the project", v => ProjectName = v);
            options.Add("environment=", "Name of the environment.", v => EnvironmentName = v);
            options.Add("tenant=", "Name of the tenant.", v => TenantName = v);
        }

        public async Task Request()
        {
            var features = await Repository.FeaturesConfiguration.GetFeaturesConfiguration();
            if (features.IsMultiTenancyEnabled)
            {
                tenant = await Repository.Tenants.FindByName(TenantName);
                if (tenant == null)
                {
                    throw new CommandException($"Tenant {TenantName} was not found");
                }

                var environment = await Repository.Environments.FindByName(EnvironmentName);
                if (environment == null)
                {
                    throw new CommandException($"Environment {EnvironmentName} was not found");
                }

                var project = await Repository.Projects.FindByName(ProjectName);
                if (project == null)
                {
                    throw new CommandException($"Project {ProjectName} was not found");
                }

                tenant.ConnectToProjectAndEnvironments(project, environment);
                await Repository.Tenants.Modify(tenant);
            }
            else
            {
                throw new CommandException("Multi-Tenancy is not enabled");
            }
        }

        public void PrintDefaultOutput()
        {
            if (tenant != null)
            {
                commandOutputProvider.Information("{Tenant:l} (ID: {Count})", tenant.Name, tenant.Id);
                foreach (var tenantProjectEnvironment in tenant.ProjectEnvironments)
                {
                    commandOutputProvider.Information(" - {Project:l}", tenantProjectEnvironment.Key);
                    foreach (var s in tenantProjectEnvironment.Value)
                    {
                        commandOutputProvider.Information("  - {Environment:l}", s);
                    }
                }
            }
        }

        public void PrintJsonOutput()
        {
            if (tenant != null)
            {
                commandOutputProvider.Json(
                    new
                    {
                        tenant.Id,
                        tenant.Name,
                        tenant.ProjectEnvironments,
                        tenant.TenantTags
                    }
                );
            }
        }
    }
}
