open DbContext

[<EntryPoint>]
let main argv =
    let dbContext = TestDbContextFactory().CreateDbContext()
    let result = Database.Repository(dbContext).insertAppointment() |> Async.RunSynchronously
    // let query = Database.Repository(dbContext).getPersonTuple( 1 ) // Nested expression error
    //let query = Database.Repository(dbContext).getPersonRecord( 1 ) // Operation is not valid error
    //printfn "%s" query
    0