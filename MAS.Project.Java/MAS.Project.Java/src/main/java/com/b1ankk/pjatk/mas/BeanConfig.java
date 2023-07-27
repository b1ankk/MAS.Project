package com.b1ankk.pjatk.mas;

import com.zaxxer.hikari.HikariDataSource;
import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.boot.jdbc.DataSourceBuilder;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import javax.sql.DataSource;

@Configuration
public class BeanConfig {

    @ConfigurationProperties(prefix = "app.datasource")
    @Bean
    public static DataSource dataSource() {
        return DataSourceBuilder.create().type(HikariDataSource.class).build();
    }

}
