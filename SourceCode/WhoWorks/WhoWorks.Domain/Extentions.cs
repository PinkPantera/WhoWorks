﻿using WhoWorks.Domain.Models;
using WhoWorks.Domain.ModelsDto;

namespace WhoWorks.Domain
{
    public static class Extentions
    {
        public static PersonDto ToPersonDto(this Person person)
        {
            return new PersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                SecondName = person.SecondName,
                DateOfBirth = person.DateOfBirth,
                IdentityCard = person.IdentityCard,
                Address = person.Address?.ToAddressDto(),
                Photo = person.Photo?.ToPhotoDto(),
                Phone = person.Phone,
                Email = person.Email
            };
        }
        public static PhotoDto ToPhotoDto(this Photo photo)
        {
            return new PhotoDto
            {
                ImageData = photo.ImageData,
            };
        }
        public static AddressDto ToAddressDto(this Address address)
        {
            return new AddressDto
            {
                ShortAddress = address.ShortAddress,
                Town = address.Town,
                Region = address.Region,
                Country = address.Country,
                CityCode = address.CityCode,
            };
        }

        public static Person ToPerson(this PersonDto personDto)
        {
            return new Person
            {
                Id = personDto.Id,
                FirstName = personDto.FirstName,
                SecondName = personDto.SecondName,
                DateOfBirth = personDto.DateOfBirth,
                IdentityCard = personDto.IdentityCard,
                Address = personDto.Address?.ToAddress(),
                Photo = personDto.Photo?.ToPhoto(),
                Phone = personDto.Phone,
                Email = personDto.Email
            };
        }

        public static Photo ToPhoto(this PhotoDto photoDto)
        {
            return new Photo
            {
                ImageData = photoDto.ImageData,
            };
        }

        public static Address ToAddress(this AddressDto addressDto)
        {
            return new Address
            {
                ShortAddress = addressDto.ShortAddress,
                Town = addressDto.Town,
                Region = addressDto.Region,
                Country = addressDto.Country,
                CityCode = addressDto.CityCode,
            };
        }
    }
}
