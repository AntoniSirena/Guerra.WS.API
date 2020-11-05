﻿using JS.Base.WS.API.DBContext;
using JS.Base.WS.API.Helpers;
using JS.Base.WS.API.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JS.Base.WS.API.Services
{
    public class FileDocument: IFileDocument
    {
        private MyDBcontext db;
        private long currentUserId = CurrentUser.GetId();

        public FileDocument()
        {
            db = new MyDBcontext();
        }


        public void SaveFile(string name, string path, bool isPublic, string contentType)
        {
            var file = new Models.FileDocument.FileDocument()
            {
                Name = name,
                Path = path,
                IsPublic = isPublic,
                ContentType = contentType,
                CreationTime = DateTime.Now,
                CreatorUserId = currentUserId,
                IsActive = true,
            };


            var validateFile = db.FileDocuments.Where(x => x.Name == name & x.IsActive == true).FirstOrDefault();

            if (validateFile != null)
            {
                validateFile.LastModificationTime = DateTime.Now;
                validateFile.LastModifierUserId = currentUserId;
            }
            else
            {
               db.FileDocuments.Add(file);
            }

            db.SaveChanges();
        }

    }
}