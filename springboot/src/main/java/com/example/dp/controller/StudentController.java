package com.example.dp.controller;

import com.example.dp.models.Student;
import com.example.dp.repositories.StudentRepository;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("")
@Slf4j
public class StudentController {
    @Autowired
    private StudentRepository studentRepository;

    @GetMapping("/student")
    public List<Student> allStudents() {
        return studentRepository.findAll();
    }

    @GetMapping("/student/{id}")
    public Student getStudentById(@PathVariable("id") long id) {
        return studentRepository.findById(id).orElseThrow(() -> new IllegalArgumentException("Invalid argument id " + id));
    }

    @GetMapping("/students")
    public List<Student> getStudentByName(@RequestParam(name="name") String name) {
        return studentRepository.findAllByFirstName(name);
    }

    @PostMapping("/student")
    public void newStudent(@RequestBody Student student) {
        studentRepository.save(student);
    }

}
