namespace Database

open DbContext
open Model
open System.Linq
//open FSharpComposableQuery
open Microsoft.FSharp.Linq
open LinqToDB.EntityFrameworkCore
open LinqToDB

type Repository(context : AppDbContext) =
    member _.insertAppointment() =
        let event : AppointmentCalendarEvent = {
            Id = 0 // For inserts with auto-generated PK
            AdiId = 0
            StartTime = System.DateTime.UtcNow
            EndTime = System.DateTime.UtcNow
        }

        task {
            try
                let! eventId = context.CreateLinqToDbContext().InsertWithInt32IdentityAsync(event)
                return event |> Result.Ok
            with
            | e ->
                return Result.Error e
        } |> Async.AwaitTask


    //member _.getPersonTuple(id : int) =
    //    let q =
    //        context
    //            .Person
    //            .Where(fun p -> p.Id = id)
    //            .Join(
    //                context.Companies,
    //                (fun p -> p.Id),
    //                (fun c -> c.Id),
    //                (fun p c ->
    //                    (p, c)) )
    //            .LeftJoin(
    //                context.CompaniesInformation,
    //                (fun (p, c) cInfo -> c.Id = cInfo.Id),
    //                (fun (p, c) cInfo ->
    //                    (p, c, cInfo)
    //                ))
    //    q.ToLinqToDB().ToString()

    //member _.getPersonRecord(id : int) =
    //    LinqToDBForEFTools.Initialize()
    //    let q =
    //        context
    //            .Person
    //            .Where(fun p -> p.Id = id)
    //            .Join(
    //                context.Companies,
    //                (fun p -> p.Id),
    //                (fun c -> c.Id),
    //                (fun p c ->
    //                    {|
    //                        Person = p
    //                        Company = c
    //                    |}) )
    //            .LeftJoin(
    //                context.CompaniesInformation,
    //                (fun partialPerson cInfo -> partialPerson.Company.Id = cInfo.Id),
    //                (fun partialPerson cInfo ->
    //                    {|
    //                        Person = partialPerson.Person
    //                        Company = partialPerson.Company
    //                        CompanyInformation = cInfo
    //                    |}) )
    //    q.ToLinqToDB().ToString()