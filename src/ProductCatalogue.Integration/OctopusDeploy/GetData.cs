using System;
using System.Threading.Tasks;
using Octopus.Client;

namespace ProductPages.Integration.OctopusDeploy
{
   public class GetData
   {
       private OctopusServerEndpoint _endpoint;

        public GetData(string apiKey, string serverUrl)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                ThrowArgumentException(nameof(apiKey));
            }

            if (string.IsNullOrEmpty(serverUrl))
            {
                ThrowArgumentException(nameof(serverUrl));
            }

            _endpoint = new OctopusServerEndpoint(serverUrl, apiKey);
        }

       private static void ThrowArgumentException(string nameOfInputVariable)
       {
           throw new ArgumentException($"The {nameOfInputVariable} cannot be null or empty");
       }

       public async Task<Octopus.Client.Model.ProjectResource> GetProjectByName(string projectByName)
       {
           if (string.IsNullOrEmpty(projectByName))
           {
               ThrowArgumentException(nameof(projectByName));
           }

           using (var client = await OctopusAsyncClient.Create(_endpoint))
           {
               var repository = new OctopusAsyncRepository(client);

               var project = await repository.Projects.FindByName(projectByName);
               return project;
           }
       }
   }
}
