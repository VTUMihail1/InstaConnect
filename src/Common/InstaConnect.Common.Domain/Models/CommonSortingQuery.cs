namespace InstaConnect.Common.Domain.Models;

public record CommonSortingQuery<TSortProperty>(
    CommonSortOrder Order,
    TSortProperty Property)
    where TSortProperty : Enum;
