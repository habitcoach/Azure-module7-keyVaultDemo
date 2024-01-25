using System;
using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

class Program
{
    static void Main(string[] args)
    {
        string secretName = "myNewSecret01";
        string keyVaultName = "kv166174keyvault ";
        var kvUri = "https://kv166174keyvault.vault.azure.net/";

        string clientId = "c7e4ca87-c4ac-4076-aec7-ee8443f737b6";
        var clientSecret = "fOm8Q~8bbPKUZVEgC2FgkWqTUaynU2UtqmGRlaov";
        string tenantId = "eacd8611-1b49-4c56-af05-1fa562f0df43";



        var credentials = new ClientSecretCredential(tenantId, clientId, clientSecret);



        //var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

        var client = new SecretClient(new Uri(kvUri), credentials);

       Console.Write("Input the value of your secret > ");
        string secretValue = Console.ReadLine();

       Console.Write("Creating a secret in " + keyVaultName + " called '" + secretName + "' with the value '" + secretValue + "' ...");

        client.SetSecret(secretName, secretValue);
        

       Console.WriteLine(" done.");

        Console.WriteLine("Forgetting your secret.");
        secretValue = "";
        Console.WriteLine("Your secret is '" + secretValue + "'.");

        Console.WriteLine("Retrieving your secret from " + keyVaultName + ".");

        KeyVaultSecret secret = client.GetSecret(secretName);

        Console.WriteLine("Your secret is '" + secret.Value + "'.");

        Console.Write("Deleting your secret from " + keyVaultName + " ...");

    client.StartDeleteSecret(secretName);

        System.Threading.Thread.Sleep(5000);
        Console.WriteLine(" done.");

    }
}