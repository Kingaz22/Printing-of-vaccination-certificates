using Microsoft.EntityFrameworkCore;
using PrintCertVac.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrintCertVac.EntityFramework
{
    public static class GenericDataService<T> where T : DomainObject
    {
        public static T Create(T entity)
        {
            using var context = new ApplicationContext();
            if (context.Set<T>().Find(entity.Id) != null)
            {
                Edit(entity);
                return null;
            }
            var createdResult = context.Set<T>().Add(entity);
            context.SaveChanges();
            return createdResult.Entity;
        }

        /// <summary>
        /// Добавление колекции Certificate
        /// </summary>
        /// <returns>Возвращает колекцию типа Certificate</returns>
        public static IEnumerable<Certificate> AddAll(IEnumerable<Certificate> entity)
        {
            using var context = new ApplicationContext();
            if (entity != null)
            {
                foreach (var item in entity)
                {
                    if (!context.Certificates.Where(x => x.User.IdentNumber == item.User.IdentNumber).Any())
                    {
                        item.Id = new();
                        context.Certificates.Add(item);
                        context.SaveChanges();
                    }
                }
            }
            IEnumerable<Certificate> entities = context.Certificates.ToList();
            return entities;
        }

        /// <summary>
        /// Получить список
        /// </summary>
        /// <returns>Возвращает колекцию типа Т</returns>
        public static IEnumerable<T> GetAll()
        {
            using var context = new ApplicationContext();
            IEnumerable<T> entities = context.Set<T>().ToList();
            return entities;
        }

        /// <summary>
        /// Удаление одного элемента
        /// </summary>
        /// <param name="entity">Объект</param>
        /// <returns>Возвращает true или false</returns>
        public static bool Delete(T entity)
        {
            try
            {
                if (entity is null)
                {
                    return false;
                }
                using var context = new ApplicationContext();
                context.Set<T>().Remove(entity);
                context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Редактирование одного элемента
        /// </summary>
        /// <param name="entity">Объект</param>
        /// <returns>Возвращает true или false</returns>
        public static bool Edit(T entity)
        {
            try
            {
                using var context = new ApplicationContext();
                context.Set<T>().Update(entity);
                context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }

}
