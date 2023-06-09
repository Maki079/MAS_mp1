﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace mp1
{
    internal class Car
    {
        private static List<Car> carsExtent = new();
        public static List<Car> CarsExtent
        {
            get => carsExtent.ToList();
        }
        public static int CarsCount 
        {
            get => carsExtent.Count;
        }
        private Insurance _insurance;
        public Insurance Insurance
        {
            get => _insurance;
            set
            {
                if (value == null)
                {
                    throw new Exception("Car must have an insurance!");
                }
                else
                {
                    _insurance = value;
                }
            }
        }
        private string _vin;
        public string VIN { 
            get => _vin;
            set 
            {
                if (carsExtent.Any(car => car.VIN == value))
                {
                    throw new Exception("VIN already exists");
                }
                else if (String.IsNullOrEmpty(value)) 
                {
                    throw new Exception("VIN cannot be null or empty");
                }
                else if (value.Length != 17)
                {
                    throw new Exception("VIN must be 17 characters long");
                }
                else
                {
                    _vin = value;
                }
            }
        }
        private DateTime _manufacturedYear;
        public DateTime ManufacturedYear {
            get => _manufacturedYear;
            set 
            {
                if (value.Year > DateTime.Now.Year)
                {
                    throw new Exception("Manufactured year cannot be in the future");
                }
                else
                {
                    _manufacturedYear = value;
                }
            }
        }
        private int _age;
        public int Age
        {
            get => DateTime.Now.Year - ManufacturedYear.Year;
        }
        private int _mileageInKM;
        public int MileageInKM { 
            get=> _mileageInKM;
            set 
            {
                if (value < 0)
                {
                    throw new Exception("Mileage cannot be negative");
                }
                else
                {
                    _mileageInKM = value;
                }
            }
        }
        private int _powerInKW;
        public int PowerInKW { 
            get=> _powerInKW;
            set 
            {
                if (value < 0)
                {
                    throw new Exception("Power cannot be negative");
                }
                else
                {
                    _powerInKW = value;
                }
            }
        }   
        public int PowerInHP 
        {
            get=> (int)(PowerInKW * 1.34102209);
        }
        private string _engineType;
        public string EngineType 
        {
            get=> _engineType;
            set 
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Engine type cannot be null or empty");
                }
                else if (value != "diesel" && value != "petrol" && value != "electric" && value != "hybrid")
                {
                    throw new Exception("Engine type must be diesel, petrol, hybrid or electric");
                }
                else
                {
                    _engineType = value;
                }
            }
        }
        private string _model;
        public string Model {
            get => _model;
            set 
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Model cannot be null or empty");
                }
                else
                {
                    _model = value;
                }
            }
        }
        private string _manufacturer;
        public string Manufacturer {
            get => _manufacturer;
            set 
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Manufacturer cannot be null or empty");
                }
                else
                {
                    _manufacturer = value;
                }
            }
        }
        private List<string> _carEquipment;
        public List<string> CarEquipment 
        {
            get=> _carEquipment.ToList();
            set 
            {
                if (value == null || value.Count == 0) 
                {
                    throw new Exception("Car must have a least 1 equpemnet");
                }
                _carEquipment = value;
            }
        }
        //atrybut opcjonalny
        public string? Description { get; set; }
        //przesłonięcie
        public override string ToString()
        {
            return $"VIN: {VIN}, " +
                $"Manufactured year: {ManufacturedYear}," +
                $" Mileage: {MileageInKM}," +
                $" Power: {PowerInKW}," +
                $" Engine type: {EngineType}," +
                $" Model: {Model}," +
                $" Manufacturer: {Manufacturer}," +
                $" Car equipment: {String.Join(", ", CarEquipment)}," +
                $" Description: {Description}"; 
        }
        //metoda klasowa
        public static float GetAvarageCarAge ()
        {
            return (float)carsExtent.Average(car => car.Age);
        }
        //przeciążenie
        public static float GetAvarageCarMileage()
        {
            return (float)carsExtent.Average(car => car.MileageInKM);
        }
        public static float GetAvarageCarMileage(bool inmiles)
        {
            if(!inmiles)
                return GetAvarageCarMileage();
            return (float)carsExtent.Average(car => (car.MileageInKM)* 0.621371192);
        }
        //konstruktor
        public Car(string vin, DateTime manufacturedYear, int mileageInKM, int powerInKW, string engineType, string model, string manufacturer, List<string> carEquipment, string? description)
        {
            VIN = vin;
            ManufacturedYear = manufacturedYear;
            MileageInKM = mileageInKM;
            PowerInKW = powerInKW;
            EngineType = engineType;
            Model = model;
            Manufacturer = manufacturer;
            CarEquipment = carEquipment;
            Description = description;
            carsExtent.Add(this);
        }

    }
}
