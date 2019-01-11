using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YazariKim.Model.Entity;

namespace YazariKim.Model
{
	public class YazariKimDB : DbContext  //Database classını entitye bağlamak için miras aldık.
	{
		public YazariKimDB()
			:base(@"Data Source=DESKTOP-5SFLSAG\SQLEXPRESS;Initial Catalog=YazariKimDB;Integrated Security=True")
		{

		}
		//Tablolar burada bulunacaktır.
		

		public DbSet<Book> Books { get; set; } // Book tablosu

		public DbSet<Languages> Lang { get; set; }// Languages tablosu ana database e eklemiş oluyoruz.

		public DbSet<Types> Types { get; set; } // Type tablosu

		public DbSet<Book_Type> Book_Types { get; set; } // Book_Type tablosu

		public DbSet<Book_Pictures> Book_Pictures { get; set; } // Pictures Tablosu

		public DbSet<Publisher> Publishers { get; set; }// Publisher tablosu

		public DbSet<Book_Publisher> Book_Publishers { get; set; } // Book_Publisher tablosu

		public DbSet<Country> Countries { get; set; }//Country Tablosu

		public DbSet<Season> Seasons { get; set; }//Season tablosu

		public DbSet<Writer> Writers { get; set; }// Yazar tablosu

		public DbSet<Writer_Pictures> Writer_Pictures { get; set; } // Writer Picture Tablosu

		public DbSet<Writer_Season> Writer_Seasons { get; set; }// Writer season tablosu

		public DbSet<Job> Jobs { get; set; }//Job tablosu

		public DbSet<Writer_Job> Writer_Jobs { get; set; }//Writer Job tablosu

		public DbSet<Writer_Book> Writer_Books { get; set; }//writer book tablosu

		public DbSet<User> Users { get; set; } // User tablosu

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			base.OnModelCreating(modelBuilder);		
		}

	}

}
