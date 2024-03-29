﻿using BackendOrganizationManagement.Main.Dto;
using BackendOrganizationManagement.Main.Util;
using BackendOrganizationManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BackendOrganizationManagement.Main.Service
{
    public class SectionService

        : BaseService
    {

        public override List<object> ObjectList(int offset, int limit)
        {
            List<object> ObjList = new List<object>();
            dbEntities = new mpi_dbEntities();
            var Sql = (from p in dbEntities.sections orderby p.name select p);
            List<section> List = Sql.Skip(offset * limit).Take(limit).ToList();
            foreach (section c in List)
            {
                ObjList.Add(c);
            }
            count = dbEntities.sections.Count();
            return ObjList;
        }
        public override BaseEntity Update(object Obj)
        {
            dbEntities = new mpi_dbEntities();
            section section = (section)Obj;
            section DBsection = (section)GetById(section.id);
            if (DBsection == null)
            {
                return null;
            }
            dbEntities.Entry(DBsection).CurrentValues.SetValues(section);
            try
            {
                dbEntities.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            return section;
        }

        public override BaseEntity GetById(object Id)
        {
            dbEntities = new mpi_dbEntities();
            section section = (from c in dbEntities.sections where c.id == (int)Id select c).SingleOrDefault();
            return section;
        }

        public override bool Delete(object Obj)
        {
            try
            {
                section section = (section)Obj;
                dbEntities = new mpi_dbEntities();
                dbEntities.sections.Remove(section);
                dbEntities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }




        public override int ObjectCount()
        {
            return count;// dbEntities.sections.Count();
        }

        public override BaseEntity Add(object Obj)
        {
            section section = (section)Obj;
            dbEntities = new mpi_dbEntities();
            section newsection = dbEntities.sections.Add(section);
            try
            {
                dbEntities.SaveChanges();
                return newsection;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {

                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
                //  return null;
            }

        }

        public override List<object> SqlList(string sql, int limit = 0, int offset = 0)
        {
            List<object> categoryList = new List<object>();
            dbEntities = new mpi_dbEntities();
            var sections = dbEntities.sections
                .SqlQuery(sql
                ).
                Select(section => new
                {
                    section
                });
            if (limit > 0)
            {
                sections = sections.Skip(offset * limit).Take(limit).ToList();
            }
            else
            {
                sections = sections.ToList();
            }
            foreach (var u in sections)
            {
                section section = u.section;
                categoryList.Add(section);
            }
            count = countSQL(sql, dbEntities.sections);

            return categoryList;
        }
         
        public override int countSQL(string sql, object dbSet)
        {
            return ((DbSet<section>)dbSet)
                .SqlQuery(sql).Count();
        }

    }
}