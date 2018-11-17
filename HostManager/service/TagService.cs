using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HostManager.dao;

namespace HostManager.service
{
    class TagService
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

        internal void AddTag(List<Tag> NewTagList)
        {
            m_TagRepository.Save(NewTagList);
        }
    }
}
