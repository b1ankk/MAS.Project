package com.b1ank.maskotlin

import org.springframework.web.bind.annotation.GetMapping
import org.springframework.web.bind.annotation.PostMapping
import org.springframework.web.bind.annotation.RequestBody
import org.springframework.web.bind.annotation.RestController

@RestController
class MessageController(val service: MessageService) {

    @GetMapping
    fun index(name: String?) = service.findMessages();

    @PostMapping
    fun post(@RequestBody message: Message) {
        service.save(message);
    }

}