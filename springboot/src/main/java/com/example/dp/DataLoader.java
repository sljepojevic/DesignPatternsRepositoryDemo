package com.example.dp;

import com.example.dp.models.Student;
import com.example.dp.repositories.StudentRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.ApplicationArguments;
import org.springframework.boot.ApplicationRunner;
import org.springframework.stereotype.Component;

@Component
public class DataLoader implements ApplicationRunner {

    private final StudentRepository studentRepository;

    @Autowired
    public DataLoader(StudentRepository studentRepository){
        this.studentRepository = studentRepository;
    }

    @Override
    public void run(ApplicationArguments args) {
        studentRepository.save(new Student("Carson", "Alexander"));
        studentRepository.save(new Student("Carson", "Mendela"));
        studentRepository.save(new Student("Carson", "DaVinci"));
        studentRepository.save(new Student("Meredith", "Alonso"));
        studentRepository.save(new Student("Arturo", "Anand"));
        studentRepository.save(new Student("Gytis", "Barzdukas"));
        studentRepository.save(new Student("Yan", "Li"));
        studentRepository.save(new Student("Peggy", "Justice"));
        studentRepository.save(new Student("Laura", "Norman"));
        studentRepository.save(new Student("Nino", "Olivetto"));
    }
}
