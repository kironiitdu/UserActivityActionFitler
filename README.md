

## Db Context For Asp.net core Database First

Let's imagine your database has below entity. 

<img src="https://i.stack.imgur.com/bWuyn.png" alt="user avatar" width="278" height="491" class="bar-sm bar-md d-block">  

In this scenario your ApplicationDbContext should construct as below

## ApplicationDbContext

```
 public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Categories> Categories  { get; set; }
       

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().ToTable("Categories");
        }
    }
    
  ```
## appsettings.json

  ```
  {
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=YourServerName;Database=Northwind;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "AllowedHosts": "*"
}
  ```
