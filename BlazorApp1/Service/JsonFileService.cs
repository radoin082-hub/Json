using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using BlazorApp1.Model;

namespace BlazorApp1.Service
{
    public class JsonFileService
    {
        private readonly string _filePath = "C://Users//radoi/RiderProjects/ConsoleApp1/BlazorApp1/wwwroot/Data.json";

       
        private void EnsureFileExists()
        {
            if (!File.Exists(_filePath) || string.IsNullOrWhiteSpace(File.ReadAllText(_filePath)))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }

        public List<Item> GetAll()
        {
            try
            {
                string json = File.ReadAllText(_filePath);
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                return JsonSerializer.Deserialize<List<Item>>(json, options) ?? new List<Item>();
            }
            catch (JsonException)
            {
                Console.WriteLine("invalid json ");
                return new List<Item>();
            }
        }

        public void Add(Item item)
        {
            var items = GetAll();
            items.Add(item);
            Save(items);
        }

        public void Update(Item updatedItem)
        {
            var items = GetAll();
            var index = items.FindIndex(x => x.Id == updatedItem.Id);
            if (index != -1)
            {
                items[index] = updatedItem;
                Save(items);
            }
        }

        public void Delete(int id)
        {
            var items = GetAll();
            items.RemoveAll(x => x.Id == id);
            Save(items);
        }

        private void Save(List<Item> items)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            string json = JsonSerializer.Serialize(items, options);
            File.WriteAllText(_filePath, json);
        }
    }
}
