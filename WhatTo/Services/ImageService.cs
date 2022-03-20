using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WhatTo.Models.Services
{
    public class ImageService
    {
        private readonly IConfiguration settings;

        public ImageService(IConfiguration _settings)
        {
            //This is always null
            settings = _settings;
        }
            public async Task<string> UploadImageAsync(IFormFile imageToUpload, string container)
            {
                string imageFullPath = null;
                if (imageToUpload == null || imageToUpload.Length == 0)
                {
                    return null;
                }
            try
            {
                IConfigurationSection keysSection = settings.GetSection("Keys");
                string accountName = keysSection.GetSection("StorageAccountName").Value;
                string accountKey = keysSection.GetSection("StorageAccountKey").Value;

                StorageCredentials storageCredentials = new StorageCredentials(accountName, accountKey);
                CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(storageCredentials, true);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(container);

                if (await cloudBlobContainer.CreateIfNotExistsAsync())
                {
                    await cloudBlobContainer.SetPermissionsAsync(
                        new BlobContainerPermissions
                        {
                            PublicAccess = BlobContainerPublicAccessType.Blob
                        }
                        );
                }
                string imageName = Guid.NewGuid().ToString() + "-" + Path.GetExtension(imageToUpload.FileName);

                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(imageName);
                cloudBlockBlob.Properties.ContentType = imageToUpload.ContentType;
                await cloudBlockBlob.UploadFromStreamAsync(imageToUpload.OpenReadStream());

                imageFullPath = cloudBlockBlob.Uri.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return imageFullPath;
        }
    }
}
