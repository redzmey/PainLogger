using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Newtonsoft.Json;
using PainLogger.Model.Interfaces;

namespace PainLogger.Model.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : IElement
    {
        private List<T> _elementsList;

        public List<T> ElementsList
        {
            get { return _elementsList ?? GetAll().Result; }
            set { _elementsList = value; }
        }

        public static StorageFolder LocalFolder => ApplicationData.Current.LocalFolder;

        public virtual async Task AddNew(T element, List<T> list = null)
        {
            ElementsList = list;
            if (await IsExistst(element) == false)
            {
                list?.Add(element);
                await WriteFile(list);
            }
        }

        public virtual async Task Delete(T element, List<T> list = null)
        {
            ElementsList = list;
            if (await IsExistst(element) == true)
            {
                list?.Remove(element);
                await WriteFile(list);
            }
        }

        public virtual async Task<List<T>> GetAll()
        {
            if (await LocalFolder.TryGetItemAsync(typeof (T).ToString()) == null)
                return null;

            StorageFile textFile = await LocalFolder.GetFileAsync(typeof (T).ToString());
            string content = await FileIO.ReadTextAsync(textFile);

            return JsonConvert.DeserializeObject<List<T>>(content);
        }

        //public virtual T GetOne(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        public virtual async Task<bool> IsExistst(T element)
        {
            return ElementsList.Any(x => x.Id == element.Id);
        }

        private static async Task WriteFile(List<T> list)
        {
            StorageFile textFile = await LocalFolder.CreateFileAsync(typeof (T).ToString(),
                                                                     CreationCollisionOption.ReplaceExisting);
            string jsonContents = JsonConvert.SerializeObject(list);
            using (IRandomAccessStream textStream = await textFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                using (DataWriter textWriter = new DataWriter(textStream))
                {
                    textWriter.WriteString(jsonContents);
                    await textWriter.StoreAsync();
                }
            }
        }

        //}
        //    throw new NotImplementedException();
        //{

        //public virtual void Update(T element)
    }
}