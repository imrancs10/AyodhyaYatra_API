﻿namespace AyodhyaYatra.API.DTO.Response.Visitor
{
    public class VisitorDocumentTypeResponse
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int MinDocNumber { get; set; }
        public int MaxDocNumber { get; set; }
        public string? DocNumberDataType { get; set; }
    }
}
