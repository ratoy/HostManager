using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HostTools.dao;

namespace HostTools.service
{
    public class TagService
    {
        TagRepository m_TagRepository = new TagRepository();
        HostTagRepository m_HostTagRepository = new HostTagRepository();

        public void AddTag(Tag tag)
        {
            m_TagRepository.Save(tag);
        }

        public void DeleteByTagName(String tagName)
        {
            Tag tag = m_TagRepository.FindByTagName(tagName);
            if (tag==null)
            {
                return;
            }
            m_TagRepository.DeleteByTagName(tagName);

            m_HostTagRepository.DeleteByTagId(tag.Id);
        }

        public List<Tag> GetAllTags()
        {
            return m_TagRepository.FindAll();
        }

        public void AddTag(List<Tag> NewTagList)
        {
            m_TagRepository.Save(NewTagList);
        }

        public Dictionary<string, List<Host>> GetTagHosts(List<Host> hostList)
        {
            Dictionary<string, List<Host>> DictTagHost = new Dictionary<string, List<Host>>();
            List<Tag> TagList = GetAllTags();
            foreach (Tag tag in TagList)
            {
                DictTagHost[tag.Name] = new List<Host>();
            }

            //add os
            List<String> OSList = hostList.Select(x => x.OS).Distinct(StringComparer.CurrentCultureIgnoreCase).ToList();
            foreach (String os in OSList)
            {
                DictTagHost[os.ToLower()] = new List<Host>();
            }

            foreach (Host h in hostList)
            {
                DictTagHost[h.OS.ToLower()].Add(h);
                foreach (Tag tag in h.Tags)
                {
                    DictTagHost[tag.Name].Add(h);
                }
            }

            foreach (KeyValuePair<String, List<Host>> kv in DictTagHost)
            {
                kv.Value.Sort(new HostTools.dao.HostRepository.IPComparer()); ;
            }
            return DictTagHost;
        }
    }
}
