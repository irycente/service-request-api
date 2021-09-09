namespace Domain.Dto
{
    /// <summary>
    /// Assumed that this are the fields that the user needs to provide to create a new Service Request. Normally I'd validate with BA if not in User Story.
    /// </summary>
    public class ServiceRequestCreateDto
    {
        public string BuildingCode { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
    }
}
