module Model

open System.ComponentModel.DataAnnotations
open System.ComponentModel.DataAnnotations.Schema

[<CLIMutable>]
type CompanyInformation = {
    [<Key>]
    [<ForeignKey "Company">]
    [<DatabaseGenerated(DatabaseGeneratedOption.Identity)>]
    Id: int
    Name : string
    TypeOfCorporation : string
    PhoneNumber : string
    Email : string
}

[<CLIMutable>]
type Company = {
    [<Key>]
    [<DatabaseGenerated(DatabaseGeneratedOption.Identity)>]
    Id : int
    VatNumber : string
    BankAccount : string
    TermOfPayment : int
    VatLiable : bool
    // Address
    Street : string
    Number : string
    PostalCode : string
    City : string

    IsSoleProprietor : bool
    IsCorporation : bool
}

[<CLIMutable>]
type Person = {
    [<Key>]
    [<DatabaseGenerated(DatabaseGeneratedOption.Identity)>]
    Id : int
    LastName : string
    FirstName : string
    Email : string
    PhoneNumber : string
    // Address
    Street : string
    Number : string
    Postcode : string
    City : string

    [<ForeignKey "Company">]
    CompanyId : int
}