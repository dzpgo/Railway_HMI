using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL_OF_REPOSITORIES
{
    public class LimitUltrahighTagValue
    {
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDataProvider = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();

        private Baosight.iSuperframe.TagService.DataCollection<object> inDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();
        //step1
        public void InitTagDataProvide(string tagServiceName)
        {
            try
            {
                tagDataProvider.ServiceName = tagServiceName;
            }
            catch (Exception ex)
            {
            }
        }

        private List<string> lstTagName = new List<string>();

        //step2
        public void AddTagName(string tagName)
        {
            try
            {
                lstTagName.Add(tagName);
            }
            catch (Exception ex)
            {
            }
        }
        public long GetTagValue(string tagName)
        {
            long tagValue = 0;
            readTags();
            tagValue =  get_value_x(tagName);
            return tagValue;
        }


        private string[] arrTagAdress;
        public void SetReady()
        {
            try
            {
               // tagDataProvider.ServiceName = SaddleBase.tagServiceName;
                List<string> lstAdress = new List<string>();
                foreach (string tagName in lstTagName)
                {
                    lstAdress.Add(tagName);
                }    
                arrTagAdress = lstAdress.ToArray<string>();
                lstAdress.Clear();
            }
            catch (Exception er)
            {

            }
        }

        private void readTags()
        {
            try
            {
                inDatas.Clear();
                tagDataProvider.GetData(arrTagAdress, out inDatas);
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// 取tag值
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        private long get_value_x(string tagName)
        {
            long theValue = 0;
            object valueObject = null;
            try
            {
                valueObject = inDatas[tagName];
                theValue = Convert.ToInt32(valueObject);
            }
            catch
            {
                valueObject = null;
            }
            return theValue; 
        }
    }
}
