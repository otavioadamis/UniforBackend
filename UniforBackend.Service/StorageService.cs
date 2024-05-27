using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs.ImageTOs;
using UniforBackend.Domain.Models.DTOs.S3TOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Service
{
    public class StorageService : IStorageService
    {
        private readonly string _bucketName;
        private readonly AwsCredentials _awsCredentials;

        public StorageService(IConfiguration configuration)
        {
            _bucketName = configuration["AwsConfiguration:BucketName"];

            _awsCredentials = new AwsCredentials()
            {
                AwsKey = configuration["AwsConfiguration:AWSAccessKey"],
                AwsSecret = configuration["AwsConfiguration:AWSSecretKey"]
            };

        }

        public async Task<S3ResponseDTO> UploadFileAsync(IFormFile image, string nome, string fileExt, int index)
        {

            // Credenciais para acesso
            var credentials = new BasicAWSCredentials(_awsCredentials.AwsKey, _awsCredentials.AwsSecret);

            // Definindo a região do bucket
            var config = new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.USEast1
            };

            var response = new S3ResponseDTO();

            await using var memoryStream = new MemoryStream();
            await image.CopyToAsync(memoryStream);

            S3Objeto s3obj = new S3Objeto()
            {
                BucketName = _bucketName,
                InputStream = memoryStream,
                Name = $"{nome}_{index}{fileExt}"
            };

            try
            {
                var uploadRequest = new TransferUtilityUploadRequest()
                {
                    InputStream = s3obj.InputStream,
                    Key = s3obj.Name,
                    BucketName = s3obj.BucketName,
                    CannedACL = S3CannedACL.NoACL
                };

                using var client = new AmazonS3Client(credentials, config);
                var transferUtility = new TransferUtility(client);
                await transferUtility.UploadAsync(uploadRequest);
                response.StatusCode = 200;
                response.Message = $"{s3obj.Name} enviado com sucesso.";
            }
            catch (AmazonS3Exception ex)
            {
                response.StatusCode = (int)ex.StatusCode;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<S3ResponseDTO> DeleteFileAsync(string key)
        {

            // Credenciais para acesso
            var credentials = new BasicAWSCredentials(_awsCredentials.AwsKey, _awsCredentials.AwsSecret);

            // Definindo a região do bucket
            var config = new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.USEast1
            };

            var response = new S3ResponseDTO();

            try
            {
                var deleteObjectRequest = new DeleteObjectRequest()
                {
                    BucketName = _bucketName,
                    Key = key
                };

                using var client = new AmazonS3Client(credentials, config);
                var responseDelete = await client.DeleteObjectAsync(deleteObjectRequest);

                response.StatusCode = (int)responseDelete.HttpStatusCode;
                response.Message = $"Arquivo {key} deletado com sucesso.";
            }
            catch (AmazonS3Exception ex)
            {
                response.StatusCode = (int)ex.StatusCode;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
