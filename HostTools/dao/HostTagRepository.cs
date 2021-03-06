﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HostTools.entity;
using System.Data;

namespace HostTools.dao
{
    class HostTagRepository
    {
        IDbTools m_SqliteOpera = DbOperation.Instance.GetSqliteOpera();

        public void Save(List<HostTag> HostTagList)
        {
            List<String> sqlList = new List<string>();
            String sqlBasicTag = "insert into host_tag(host_id,tag_id) values";
            StringBuilder sbuilder = new StringBuilder(sqlBasicTag);
            foreach (HostTag ht in HostTagList)
            {
                sbuilder.AppendFormat("({0},{1})", ht.HostId, ht.TagId);
                sqlList.Add(sbuilder.ToString());

                sbuilder = new StringBuilder(sqlBasicTag);
            }

            m_SqliteOpera.BatProcess(sqlList);
        }

        public void DeleteByHostId(int HostId)
        {
            m_SqliteOpera.DeleteData("delete from host_tag where host_id=" + HostId);
        }

        public List<Tag> FindByHostId(int HostId)
        {
            DataTable dtTag = m_SqliteOpera.Query("select t.id as tag_id, t.name as tag_name from tag t, host_tag ht where ht.tag_id=t.id and ht.host_id=" + HostId);
            List<Tag> TagList = new List<Tag>();

            foreach (DataRow dr in dtTag.Rows)
            {
                Tag tag = new Tag(Convert.ToInt32(dr["tag_id"]), Convert.ToString(dr["tag_name"]));

                TagList.Add(tag);
            }
            return TagList;
        }

        public void DeleteByTagId(int tagId)
        {
            m_SqliteOpera.DeleteData("delete from host_tag where tag_id=" + tagId);
        }
    }
}
