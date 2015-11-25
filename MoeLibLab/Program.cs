// ***********************************************************************
// Project          : MoeLib
// File             : Program.cs
// Created          : 2015-11-20  5:55 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-25  2:11 PM
// ***********************************************************************
// <copyright file="Program.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Moe.Lib;
using Moe.Lib.Jinyinmao;
using MoeLib.Diagnostics;

namespace MoeLibLab
{
    public class Apple
    {
        public string Color { get; set; }
        public Dictionary<string, object> Infos { get; set; }
        public DateTime ProductTime { get; set; }
        public int Size { get; set; }
    }

    internal class Program
    {
        private static readonly Lazy<ILogger> logger = new Lazy<ILogger>(() => InitApplicationLogger());

        public static ILogger Logger
        {
            get { return logger.Value; }
        }

        private static void GenerateRSAKeys(string storageConnectiongString, int count = 1000)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(storageConnectiongString);
            CloudBlobClient blobClient = account.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference("keys");

            Parallel.For(0, count, i =>
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
                string publicKey = rsa.ToXmlString(false);
                string privateKey = rsa.ToXmlString(true);

                string publicKeyEncoded = publicKey.HtmlEncode();
                string privateKeyEncoded = privateKey.HtmlEncode();

                Guid id = Guid.NewGuid();

                CloudBlockBlob publicBlob = blobContainer.GetBlockBlobReference($"{id.ToGuidString()}-public");
                CloudBlockBlob privateBlob = blobContainer.GetBlockBlobReference($"{id.ToGuidString()}-private");
                CloudBlockBlob publicEncodedBlob = blobContainer.GetBlockBlobReference($"{id.ToGuidString()}-public-encoded");
                CloudBlockBlob privatEncodedeBlob = blobContainer.GetBlockBlobReference($"{id.ToGuidString()}-private-encoded");

                publicBlob.Properties.ContentEncoding = "UTF-8";
                publicBlob.Properties.ContentType = "application/xml";

                privateBlob.Properties.ContentEncoding = "UTF-8";
                privateBlob.Properties.ContentType = "application/xml";

                publicEncodedBlob.Properties.ContentEncoding = "UTF-8";
                publicEncodedBlob.Properties.ContentType = "text/plain";

                privatEncodedeBlob.Properties.ContentEncoding = "UTF-8";
                privatEncodedeBlob.Properties.ContentType = "text/plain";

                publicBlob.UploadText(publicKey);
                privateBlob.UploadText(privateKey);
                publicEncodedBlob.UploadText(publicKeyEncoded);
                privatEncodedeBlob.UploadText(privateKeyEncoded);

                Console.WriteLine(i.ToString());
            });
        }

        private static ILogger InitApplicationLogger()
        {
            return App.LogManager.CreateLogger();
        }

        private static void Main(string[] args)
        {
            Console.WriteLine(GuidUtility.GuidShortCode());
            //App.Initialize().Config();
            //Logger.Info(DateTime.Now.ToString("F"), "MoeLibLabLog");
        }
    }
}