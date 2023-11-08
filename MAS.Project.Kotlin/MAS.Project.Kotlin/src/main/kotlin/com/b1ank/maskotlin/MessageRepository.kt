package com.b1ank.maskotlin

import org.springframework.data.repository.CrudRepository

interface MessageRepository : CrudRepository<Message, String> {
}