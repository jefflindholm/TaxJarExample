namespace tax_api.Entities;

public class OrderEntity {
    public int id;
    public string from_country;
    public string from_zip;
    public string from_state;
    public string from_city;
    public string from_street;
    public string to_country;
    public string to_zip;
    public string to_state;
    public string to_city;
    public string to_street;
    public float amount;
    public float shipping;

    public List<ItemEntity> line_items;
}