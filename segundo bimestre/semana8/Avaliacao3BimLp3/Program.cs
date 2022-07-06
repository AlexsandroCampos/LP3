using Avaliacao3BimLp3.Database;
using Avaliacao3BimLp3.Models;
using Avaliacao3BimLp3.Repositories;

var databaseConfig = new DatabaseConfig();
var databaseSetup = new DatabaseSetup(databaseConfig);
var studentRepository = new StudentRepository(databaseConfig);

var modelName = args[0];
var modelAction = args[1];

if(modelName == "Student")
{
    if(modelAction == "New")
    {
        var registration = args[2];

        if(studentRepository.ExistsByRegistration(registration))
        {
            Console.WriteLine($"Estudante com Prontuário {registration} já existe");
        }

        else 
        {
            var name = args[3];
            var city = args[4];

            var student = studentRepository.Save(new Student(registration, name, city));

            Console.WriteLine($"Estudante {student.Name} cadastrado com sucesso");
        } 
    }

    if(modelAction == "Delete")
    {
        var registration = args[2];
        if(studentRepository.ExistsByRegistration(registration))
        {
            studentRepository.Delete(registration);
            Console.WriteLine($"Estudante {registration} removido com sucesso");
        }
        else
        {
            Console.WriteLine($"Estudante {registration} não econtrado");
        }
    }

    if(modelAction == "MarkAsFormed")
    {
        var registration = args[2];
        if(studentRepository.ExistsByRegistration(registration))
        {
            studentRepository.MarkAsFormed(registration);
            Console.WriteLine($"Estudante {registration} definido como formado");
        }
        else
        {
            Console.WriteLine($"Estudante {registration} não encontrado");
        }
    }

    if(modelAction == "List")
    {
        List<Student> students = studentRepository.GetAll();
        if(students.Count() > 0)
        {
            foreach(var student in students)
            {
                if(student.Former)
                {
                    Console.WriteLine($"Prontuário {student.Registration}, {student.Name}, {student.City}, formado");
                }
                else
                {
                    Console.WriteLine($"Prontuário {student.Registration}, {student.Name}, {student.City}, não formado");
                }
            }
        }

        else
        {
             Console.WriteLine("Nenhum estudante cadastrado");
        }
    }

    if(modelAction == "ListFormed")
    {
        List<Student> students = studentRepository.GetAllFormed();
        if(students.Count() > 0)
        {
            foreach(var student in students)
            {
                Console.WriteLine($"Prontuário {student.Registration}, {student.Name}, {student.City}, formado");
            }
        }

        else
        {
             Console.WriteLine("Nenhum estudante formado cadastrado");
        }
    }

    if(modelAction == "ListByCity")
    {
        var city = args[2];
        List<Student> students = studentRepository.GetAllStudentByCity(city);
        if(students.Count() > 0)
        {
            foreach(var student in students)
            {
                if(student.Former)
                {
                    Console.WriteLine($"Prontuário {student.Registration}, {student.Name}, {student.City}, formado");
                }
                else
                {
                    Console.WriteLine($"Prontuário {student.Registration}, {student.Name}, {student.City}, não formado");
                }
            }
        }

        else
        {
             Console.WriteLine("Nenhum estudante com a cidade passada cadastrado");
        }
    }

    if(modelAction == "ListByCities")
    {
        string[] cities = new string[args.Count()];
        for(int i = 2; i < args.Count(); i++)
        {
            cities[i-2] = args[i];
        }

        List<Student> students = studentRepository.GetAllByCities(cities);
        if(students.Count() > 0)
        {
            foreach(var student in students)
            {
                if(student.Former)
                {
                    Console.WriteLine($"Prontuário {student.Registration}, {student.Name}, {student.City}, formado");
                }
                else
                {
                    Console.WriteLine($"Prontuário {student.Registration}, {student.Name}, {student.City}, não formado");
                }
            }
        }

        else
        {
            Console.WriteLine("Nenhum estudante cadastrado");
        }
        
    }

    if(modelAction == "CountByCities")
    {
        List<CountStudentGroupByAttribute> results = studentRepository.CountByCities();
        if(results.Count() > 0)
        {
            foreach(var result in results)
            {
                Console.WriteLine($"{result.AttributeName}, {result.StudentNumber}");
            }
        }

        else
        {
            Console.WriteLine("Nenhum estudante cadastrado");
        }
    }

    if(modelAction == "CountByFormed")
    {
        List<CountStudentGroupByAttribute> results = studentRepository.CountByFormed();
        if(results.Count() > 0)
        {
            foreach(var result in results)
            {
                if(result.AttributeName.Equals("1"))
                {
                    Console.WriteLine($"Formados, {result.StudentNumber}");
                }

                else
                {
                    Console.WriteLine($"Não Formados, {result.StudentNumber}");
                }
            }
        }

        else
        {
            Console.WriteLine("Nenhum estudante cadastrado");
        }
    }
}