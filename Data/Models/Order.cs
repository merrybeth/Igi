using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.EntityFrameworkCore.Scaffolding;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [Display(Name="Введите имя")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина имени не менее 5 символов")]
        public string Name { get; set; }
        
        [Display(Name="Введите фамилию")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина фамилии не менее 5 символов")]
        public string Surname { get; set; }
        
        [Display(Name="Введите адрес")]
        [StringLength(35)]
        [Required(ErrorMessage = "Длина адреса не менее 5 символов")]
        public string Adress { get; set; }
        
        [Display(Name="Введите номер телефона")]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина номера не менее 10 знаков")]
        public string Phone { get; set; }
        
        [Display(Name="Введите Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина email не менее 5 символов")]
        public string Email { get; set; }
        
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails{ get; set; }
        
    }
}