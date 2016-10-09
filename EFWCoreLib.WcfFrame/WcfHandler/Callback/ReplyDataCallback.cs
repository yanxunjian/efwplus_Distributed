﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using EFWCoreLib.WcfFrame.DataSerialize;
using EFWCoreLib.WcfFrame.SDMessageHeader;
using EFWCoreLib.WcfFrame.ServerManage;

namespace EFWCoreLib.WcfFrame.WcfHandler
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class ReplyDataCallback : IDataReply
    {

        public string ReplyProcessRequest(HeaderParameter para, string plugin, string controller, string method, string jsondata)
        {
            return DataManage.ReplyProcessRequest(plugin, controller, method, jsondata, para);
        }

        public CacheIdentify DistributedCacheSyncIdentify(CacheIdentify cacheId)
        {
            return DistributedCacheManage.CompareCache(cacheId);
        }

        public void DistributedCacheSync(CacheObject cache)
        {
            DistributedCacheManage.SyncLocalCache(cache);
        }


        public void DistributedAllCacheSync(List<CacheObject> cachelist)
        {
            foreach (var cache in cachelist)
            {
                DistributedCacheManage.SyncLocalCache(cache);
            }
        }

    }
}