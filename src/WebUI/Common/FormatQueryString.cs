using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CleanArchitecture.WebUI.Common
{
    public class FormatQueryString : IFormatQueryString
    {
        private object Parse(string valueToConvert, Type dataType)
        {
            if (valueToConvert == "undefined" || valueToConvert == "null") 
            {
                valueToConvert = null;
            }
                
            TypeConverter obj = TypeDescriptor.GetConverter(dataType);
            object value = obj.ConvertFromString(null, CultureInfo.InvariantCulture, valueToConvert);
            return value;
        }

        public T CreateRequestObject<T>(HttpRequest req) where T : new()
        {
            var ret = new T();
            Type dataType = ret.GetType();

            //get list string of query string keys
            var queryStringKeys = HttpUtility.ParseQueryString(req.QueryString.ToString()).AllKeys.ToList().ConvertAll(d => d.ToLower());

            foreach (PropertyInfo dtProp in dataType.GetProperties())
            {
                if (dtProp.CanWrite)
                {
                    var propName = dtProp.Name.ToString().ToLower();

                    //loop through query string keys
                    for (var i = 0; i < queryStringKeys.Count(); i++)
                    {
                        var k = queryStringKeys[i];
                        if (k == propName)
                        {
                            
                            //check is parm is a generic list
                            if (dtProp.PropertyType.IsGenericType)
                            {
                                var csvList = req.Query[k].ToString().Split(',').ToList();

                                //convert list to correct data type 
                                if (dtProp.PropertyType == typeof(List<long>)) 
                                {
                                    var lst = csvList.ConvertToInt64();
                                    dtProp.SetValue(ret, lst);
                                }
                                else if (dtProp.PropertyType == typeof(List<short>))
                                {
                                    var lst = csvList.ConvertToInt16();
                                    dtProp.SetValue(ret, lst);
                                }
                                else if (dtProp.PropertyType == typeof(List<int>))
                                {
                                    var lst = csvList.ConvertToInt32();
                                    dtProp.SetValue(ret, lst);
                                }
                                if (dtProp.PropertyType == typeof(List<ulong>))
                                {
                                    var lst = csvList.ConvertToUInt64();
                                    dtProp.SetValue(ret, lst);
                                }
                                else if (dtProp.PropertyType == typeof(List<ushort>))
                                {
                                    var lst = csvList.ConvertToUInt16();
                                    dtProp.SetValue(ret, lst);
                                }
                                else if (dtProp.PropertyType == typeof(List<uint>))
                                {
                                    var lst = csvList.ConvertToUInt32();
                                    dtProp.SetValue(ret, lst);
                                }
                                else if (dtProp.PropertyType == typeof(List<byte>))
                                {
                                    var lst = csvList.ConvertToByte();
                                    dtProp.SetValue(ret, lst);
                                }
                                else if (dtProp.PropertyType == typeof(List<double>))
                                {
                                    var lst = csvList.ConvertToDouble();
                                    dtProp.SetValue(ret, lst);
                                }
                                else if (dtProp.PropertyType == typeof(List<decimal>))
                                {
                                    var lst = csvList.ConvertToDecimal();
                                    dtProp.SetValue(ret, lst);
                                }
                                else if (dtProp.PropertyType == typeof(List<float>))
                                {
                                    var lst = csvList.ConvertToFloat();
                                    dtProp.SetValue(ret, lst);
                                }
                                else 
                                {
                                    dtProp.SetValue(ret, csvList);
                                }
                            }
                            else 
                            {
                                //non list data type
                                dtProp.SetValue(ret, Parse(req.Query[k], dtProp.PropertyType), null);
                            }
                        }
                    }
                }
            }

            return ret;
        }
    }
}
