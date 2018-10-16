using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Octopus.Cli.Infrastructure;
using Octopus.Cli.Repositories;
using Octopus.Cli.Util;
using Octopus.Client;
using Octopus.Client.Model;

namespace Octopus.Cli.Commands.Machine
{
    [Command("associate-machine", Description = "Associate a machine with an environment")]
    class AssociateMachineCommand : ApiCommand, ISupportFormattedOutput
    {
        private EnvironmentResource environment;
        private MachineResource machine;

        public string EnvironmentName { get; set; }
        public string MachineName { get; set; }

        public AssociateMachineCommand(
            IOctopusClientFactory clientFactory, 
            IOctopusAsyncRepositoryFactory repositoryFactory, 
            IOctopusFileSystem fileSystem, 
            ICommandOutputProvider commandOutputProvider) : base(
            clientFactory, repositoryFactory, fileSystem, commandOutputProvider)
        {
            var options = Options.For("Association");
            options.Add("machine=", "Name of the project", v => MachineName = v);
            options.Add("environment=", "Name of the environment.", v => EnvironmentName = v);
        }

        public async Task Request()
        {
            environment = await Repository.Environments.FindByName(EnvironmentName);
            if (environment == null)
            {
                throw new CommandException($"Environment {EnvironmentName} was not found");
            }

            machine = await Repository.Machines.FindByName(MachineName);
            if (machine == null)
            {
                throw new CommandException($"Machine {MachineName} was not found");
            }

            machine.EnvironmentIds.Add(environment.Id);
            await Repository.Machines.Modify(machine);
        }

        public void PrintDefaultOutput()
        {
            if (machine != null)
            {
                commandOutputProvider.Information("{Machine:l} (ID: {Count})", machine.Name, machine.Id);
                foreach (var machineEnvironmentId in machine.EnvironmentIds)
                {
                    commandOutputProvider.Information(" - {Environment:l}", machineEnvironmentId);
                }
            }
        }

        public void PrintJsonOutput()
        {
            if (machine != null)
            {
                commandOutputProvider.Json(
                    new
                    {
                        machine.Id,
                        machine.Name,
                        machine.EnvironmentIds,
                        machine.Roles,
                        machine.TenantIds,
                        machine.TenantedDeploymentParticipation
                    }
                );
            }
        }
    }
}
