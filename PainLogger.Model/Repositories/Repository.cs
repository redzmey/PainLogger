using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Storage;
using Windows.Storage.Streams;
using Newtonsoft.Json;
using PainLogger.Model.Interfaces;

namespace PainLogger.Model.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : IElement
    {
        public virtual async void Create(T element)
        {
            string jsonContents = JsonConvert.SerializeObject(element);
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile textFile = await localFolder.CreateFileAsync(typeof(T).ToString() ,
                                                                     CreationCollisionOption.ReplaceExisting);
            using (IRandomAccessStream textStream = await textFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                using (DataWriter textWriter = new DataWriter(textStream))
                {
                    textWriter.WriteString(jsonContents);
                    await textWriter.StoreAsync();
                }
            }
        }

        public virtual List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual T GetOne(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsExistst(T element)
        {
            return GetAll().Any(x => x.Id == element.Id);
        }

        public virtual void Update(T element)
        {
            throw new NotImplementedException();
        }
    }
}