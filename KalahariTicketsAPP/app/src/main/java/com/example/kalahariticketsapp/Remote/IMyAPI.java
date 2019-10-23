package com.example.kalahariticketsapp.Remote;

import edmt.dev.andriodmvc

import io.reactivex.Observable;
import retrofit2.http.Body;
import retrofit2.http.POST;

public interface IMyAPI {
    @POST("")
    Observable<String> registerClient(@Body Client client)
}
