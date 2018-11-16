using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HostManager.dao;
using HostManager.entity;
using HostManager.vo;

namespace HostManager.service
{
    class HostService
    {
        HostRepository m_HostRepo = new HostRepository();
        HostTagRepository m_HostTagRepo = new HostTagRepository();

        public void AddHost(Host host)
        {
            host=m_HostRepo.Save(host);

            SaveHostTag(host);
        }

        void SaveHostTag(Host host,int hostId=-1)
        { 
            List<HostTag> HostTagList = new List<HostTag>();
            foreach (Tag  tag in host.Tags)
            {
                HostTag ht = new HostTag();
                ht.HostId =hostId==-1? host.Id:hostId;
                ht.TagId = tag.Id;
                HostTagList.Add(ht);
            }
            m_HostTagRepo.Save(HostTagList);
        }

        public void EditHost(int id,Host newHost)
        {
            //update host
            m_HostRepo.Update(id,newHost);
            //delete old hosttag
            m_HostTagRepo.DeleteByHostId(id);
            //insert new
            SaveHostTag(newHost, id);
        }

        public void RemoveHost(int HostId)
        {
            m_HostRepo.DeleteById(HostId);
            m_HostTagRepo.DeleteByHostId(HostId);
        }

        public List<Host> GetAllHosts()
        {
            List<Host> HostList = m_HostRepo.FindAll();
            //find tags
            foreach (Host h in HostList)
            {
                h.Tags = m_HostTagRepo.FindByHostId(h.Id);
            }

            return HostList;
        }
    }
}
