using System.IO;
using JustEnough.Models;

namespace JustEnough.Data;

public class Seed
{
    private readonly DataContext _context;
    public Seed(DataContext context)
    {
        this._context = context;
    }
    public void Initialize()
    {
        string path = "./Data/products/";
        if(!_context.Products.Any())
        {
            //initial customer
            var myuser = new Customer
            {
                UserName = "kguers462",
                FirstName = "Kyle",
                LastName = "Guers",
                Email = "mmmbuh462@gmail.com",
                Password = "@Dmin"
            };

            //initial products
            var products = new Product[]
        {
            new Product
            {
                Title = "Fifine USB Microphone",
                Category = "microphone",
                Description = "FIFINE USB Studio Recording Microphone Computer Podcast Mic for PC, PS4, Mac with Mute Button & Monitor Headphone Jack, Four Pickup Patterns for Vocals YouTube Streaming Gaming ASMR Zoom-Class (K690)",
                Image = File.ReadAllBytes(path + "Fifine-USB-Mic.jpg"),
                Price = 94.99m,
                Rating = 4.7m,
                InStock = true,
                Brand = "Fifine",
            },
            new Product
            {
                Title =  "Shinco Handheld Mic",
                Category = "microphone",
                Description = "Shinco Handheld Wired Microphone, Cardioid Dynamic Vocal Mic with 13ft Cable and ON/Off Switch, Ideally Suited for Speakers, Karaoke Singing Machine, Amp, Mixer",
                Image = File.ReadAllBytes(path + "Shinco-Handheld-mic.jpg"),
                Price = 15.99m,
                Rating = 4.2m,
                InStock = true,
                Brand = "Shinco",
            },
            new Product
            {
                Title = "Blue Snowball",
                Category = "microphone",
                Description = "Blue Snowball iCE USB Microphone for PC, Mac, Gaming, Recording, Streaming, Podcasting, with Cardioid Condenser Mic Capsule, Adjustable Desktop Stand and USB cable, Plug 'n Play – Black",
                Image = File.ReadAllBytes(path + "blue-mic.jpg"),
                Price = 49.99m,
                Rating = 4.6m,
                InStock = true,
                Brand = "Blue",
            },
            new Product
            {
                Title = "Fifine Gaming RGB Microphone",
                Category = "microphone",
                Description = "FIFINE Gaming USB Microphone for PC PS5, Condenser Mic with Quick Mute, RGB Indicator, Tripod Stand, Pop Filter, Shock Mount, Gain Control for Streaming Discord Twitch Podcasts Videos- AmpliGame",
                Image = File.ReadAllBytes(path + "rgb-gaming-mic.jpg"),
                Price = 34.99m,
                Rating = 4.4m,
                InStock = true,
                Brand = "Fifine",
            },
            new Product
            {
                Title = "Soundcore Headphones",
                Category = "headphones",
                Description = "Soundcore Anker Life Q20 Hybrid Active Noise Cancelling Headphones, Wireless Over Ear Bluetooth Headphones, 40H Playtime, Hi-Res Audio, Deep Bass, Memory Foam Ear Cups, for Travel, Home Office",
                Image = File.ReadAllBytes(path + "soundcore-headphones.jpg"),
                Price = 59.99m,
                Rating = 4.5m,
                InStock = true,
                Brand = "Soundcore",
            },
            new Product
            {
                Title = "Lorelei X6 Wired Headphones",
                Category = "headphones",
                Description = "Over-Ear Headphones with Microphone, Lightweight Foldable & Portable Stereo Bass Headphones with 1.45M No-Tangle, Wired Headphones for Smartphone Tablet MP3 / 4 (Space Black)",
                Image = File.ReadAllBytes(path + "lorelei-x6.jpg"),
                Price = 16.99m,
                Rating = 4.4m,
                InStock = true,
                Brand = "Lorelei",
            },
            new Product
            {
                Title = "OneOdio Premium Brown/Silver Headphones",
                Category = "headphones",
                Description = "Over Ear Headphone, Wired Premium Stereo Sound Headsets with 50mm Driver, Foldable Comfortable Headphones with Protein Earmuffs and Shareport for Recording Monitoring Podcast PC TV- with Mic (Silver)",
                Image = File.ReadAllBytes(path + "brown-headphones.jpg"),
                Price = 40.99m,
                Rating = 4.6m,
                InStock = true,
                Brand = "OneOdio",
            },
            new Product
            {
                Title = "Skullcandy Hesh ANC",
                Category = "headphones",
                Description = "Over-Ear Headphones, Active Noise Cancelling, Wireless Charging 22 Hours Battery Life - True Black",
                Image = File.ReadAllBytes(path + "skullcandies.jpg"),
                Price = 99.85m,
                Rating = 4.9m,
                InStock = true,
                Brand = "Skullcandy",
            },
            new Product
            {
                Title = "LVY 3.5mm Audio Selector",
                Category = "switch",
                Description = "2 Way Audio Switcher; Headphone Switcher, Stereo AUX Audio Selector, AB Switcher Selector, Audio Sharing 2(1)-in-1(2)-Out",
                Image = File.ReadAllBytes(path + "lvy-2switch.jpg"),
                Price = 21.99m,
                Rating = 3.4m,
                InStock = true,
                Brand = "LVY",
            },
            new Product
            {
                Title = "Tenealay 4 Way Switch",
                Category = "switch",
                Description = " 3.5mm Stereo Audio Switch Input Signal Source Switcher Selector Splitter Box with line Volume Controller（4 in 1 Out / 1 in 4 Out）-MC41",
                Image = File.ReadAllBytes(path + "tenealay-4switch.jpg"),
                Price = 19.89m,
                Rating = 4.1m,
                InStock = true,
                Brand = "Tenealay",
            },
            new Product
            {
                Title = "Tenealay 3-in-1 Switch",
                Category = "switch",
                Description = "3.5mm Audio Switch with line Volume Controller, 3 in 1 Out 1/8\" aux switcher Splitter selector Box, Mini Inline Headphone attenuator Volume Control knob -MC31",
                Image = File.ReadAllBytes(path + "tenealay-3switch.jpg"),
                Price = 17.99m,
                Rating = 4.7m,
                InStock = true,
                Brand = "Tenealay",
            },
        };
        
            _context.Customers.Add(myuser);
            _context.Products.AddRange(products);
            _context.SaveChanges();
        }
    }
}