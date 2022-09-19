module DbContext

open Microsoft.EntityFrameworkCore
open EntityFrameworkCore.FSharp.Extensions
open Model
open LinqToDB
open LinqToDB.Configuration
open LinqToDB.Data

type AppDbContext(options: DbContextOptions<AppDbContext>) =
    inherit DbContext(options)

    //[<DefaultValue>] val mutable companiesInformation : DbSet<CompanyInformation>
    //member this.CompaniesInformation
    //    with get() = this.companiesInformation
    //    and set v = this.companiesInformation <- v

    //[<DefaultValue>] val mutable companies : DbSet<Company>
    //member this.Companies
    //    with get() = this.companies
    //    and set v = this.companies <- v

    //[<DefaultValue>] val mutable appointmentCalendarEvents : DbSet<Person>
    //member this.Person
    //    with get() = this.person
    //    and set v = this.person <- v

    //[<DefaultValue>] val mutable person : DbSet<Person>
    //member this.Person
    //    with get() = this.person
    //    and set v = this.person <- v

    [<DefaultValue>] val mutable appointmentCalendarEvent : DbSet<AppointmentCalendarEvent>
    member this.AppointmentCalendarEvent
        with get() = this.appointmentCalendarEvent
        and set v = this.appointmentCalendarEvent <- v

    override _.OnModelCreating builder =
        builder.RegisterOptionTypes() // enables option values for all entities
    
type TestDbContextFactory() =
    member this.CreateDbContext() =
        let options = new DbContextOptionsBuilder<AppDbContext>()
        options.UseNpgsql("connectionStringHere").UseFSharpTypes() |> ignore
        new AppDbContext(options.Options)