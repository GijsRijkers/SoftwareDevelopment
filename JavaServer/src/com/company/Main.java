package com.company;

public class Main {

    public static void main(String[] args) {



        Server server = new Server();
        server.getJson();
        server.start(54000);

    }
}