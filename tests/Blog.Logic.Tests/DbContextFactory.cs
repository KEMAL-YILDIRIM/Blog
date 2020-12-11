using System;
using System.Collections.Generic;

using Blog.Domain.AuditableEntities;
using Blog.Domain.ValueObjects;
using Blog.ORM.Context;

using Microsoft.EntityFrameworkCore;

namespace Blog.Logic.Tests
{
	public class DbContextFactory
	{
		public static BlogContext Create()
		{
			var options = new DbContextOptionsBuilder<BlogContext>()
				.UseInMemoryDatabase(Guid.NewGuid().ToString())
				.Options;

			var context = new BlogContext(options);

			context.Database.EnsureCreated();

			context.Users.AddRange(new[] {
				new User ( "Adam","Cogan","ADAM", "adam.cogan@enn.www","123456",new List<Phone>{ new Phone()},null,null),
				new User ( "Jason","Taylor","JASON", "Jason.cogan@enn.www","123456",new List<Phone>{ new Phone()},null,null),
				new User ( "Brendan","Richards","BREND", "Brendan.cogan@enn.www","123456",new List<Phone>{ new Phone()},null,null),
			});


			context.SaveChanges();

			return context;
		}

		public static void Destroy(BlogContext context)
		{
			context.Database.EnsureDeleted();

			context.Dispose();
		}
	}
}
