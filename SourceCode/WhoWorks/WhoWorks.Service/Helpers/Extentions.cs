using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.Domain.Models;
using WhoWorks.Service.ModelsDto;

namespace WhoWorks.Service.Helpers
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
                AddressDto = person.Address?.ToAddressDto(),
                PhotoDto = person.Photo?.ToPhotoDto(),
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
                Address = personDto.AddressDto.ToAddress(),
                Photo = personDto.PhotoDto?.ToPhoto(),
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
