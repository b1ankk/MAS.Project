package com.b1ank.maskotlin

import org.springframework.stereotype.Service
import kotlin.jvm.optionals.toList

@Service
class MessageService(val messageRepo: MessageRepository) {

    fun findMessages(): List<Message> {
        return messageRepo.findAll().toList();
    }

    fun findMessageById(id: String): List<Message> {
        return messageRepo.findById(id).toList()
    }

    fun save(message: Message) {
        messageRepo.save(message)
    }

}