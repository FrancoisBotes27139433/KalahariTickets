package com.example.kalahariticketsapp.Model;

import java.util.Date;

public class Client {

    private String Username;

    private String Password;

    private int PhoneNumber;

    private String Email;

    private Date DateAdded;

    private String Address;

    public Client() {
    }

    public Client(String username, String password, int phoneNumber, String email, Date dateAdded, String address) {
        Username = username;
        Password = password;
        PhoneNumber = phoneNumber;
        Email = email;
        DateAdded = dateAdded;
        Address = address;
    }

    public String getUsername() {
        return Username;
    }

    public void setUsername(String username) {
        Username = username;
    }

    public String getPassword() {
        return Password;
    }

    public void setPassword(String password) {
        Password = password;
    }

    public int getPhoneNumber() {
        return PhoneNumber;
    }

    public void setPhoneNumber(int phoneNumber) {
        PhoneNumber = phoneNumber;
    }

    public String getEmail() {
        return Email;
    }

    public void setEmail(String email) {
        Email = email;
    }

    public Date getDateAdded() {
        return DateAdded;
    }

    public void setDateAdded(Date dateAdded) {
        DateAdded = dateAdded;
    }

    public String getAddress() {
        return Address;
    }

    public void setAddress(String address) {
        Address = address;
    }

    // public ICollection<TicketsForDetailedDto> Tickets { get; set; }
}
