namespace CleanArchitecture.Domain.Employees
{
    //Database tarafında bir tablo olarak tutulmayacak o yüzden record olarak tanımladım.
    //Value Object
    public sealed record PersonelInformation
    {
        public string? TCNo { get; set; }
        public string? Email { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
    }
}
