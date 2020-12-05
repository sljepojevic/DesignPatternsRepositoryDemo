package com.example.dp.models;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.*;
import java.util.List;

@Entity
@Getter
@Setter
@NoArgsConstructor
@Table(name="courses")
public class Course {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private int courseId;

    @Column(name = "title")
    private String title;

    @Column(name = "credits")
    public int credits;

    @OneToMany(mappedBy = "course")
    public List<Enrollments> enrollmentsList;
}
