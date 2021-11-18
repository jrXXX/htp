# Holiday Tech Playground

this is the backend of htp portal.

Api Doc is accessible under: http://htp-vendor-hotel2-backend2.azurewebsites.net// #FIXME change it after merge and deployment to htp-portal-backend

Azure Portal: https://portal.azure.com/#@akros.ch/resource/subscriptions/58a77e29-86fd-41a1-ac27-3c6c5879272b/resourceGroups/htp-portal-backend/providers/Microsoft.Web/sites/htp-portal-backend/appServices

## Setup

- This project is using Lombok annotations. Corresponding plugins for many IDEs are available, see: https://projectlombok.org/setup/overview.

- MariaDB must be installed with TCP port 3306 and schema Holiday


## How to start
- from the IDE
Just right click on java class `HtpBackendSpringbootApplication` and hit the `run`

- with Maven
in the hom directory of project call:
  `mvn spring-boot:run` 

- from CMD
after the building the project just call:
  `java -jar target\htp-portal-backend-0.0.1-SNAPSHOT.jar`
  

## How to start the application with docker-compose
`docker-compose up`
in this case your console will show the logs and it is not possible using the current shell

`docker-compose up -d`
in this case docker is running in the detached mode and logs can be shown with `docker-compose logs <name-of-service>`

`docker-compose down`
stop the application and stop all processes check with `docker ps -a`


## additional dependencies
- **spring boot devtool**: 
  With the spring-boot-devtools module, your application will restart every time files on the classpath change.
  the following link provided important information for configuration: https://howtodoinjava.com/spring-boot2/developer-tools-module-tutorial/
  
- **spring boot actuator**:
this is important for monitoring tools and openshift knowing the state of microservice. In this
  case actuator prepared the health information of the microservice. this link provided the state of the service:
  http://localhost:8080/actuator/health
  
## spring tests
- there are three different types of tests
- Repository which are transactional with @DataJpaTest

- Services are testing just service layer

- Controller tests are creating with three different approaches (WebTestClient,
  TestRestTemplate and MockMvc). 
  
- spring security part for checking the number of users

- all tests are configured in application-test.properties and 
separate sql script contains data and schema

## Documentation
- UML diagram of domain model. Diagram is saved under src/main/docs
- diagram of Spring cloud configuration server/client
- diagram of Spring session with Redis/JDBC
- OAuth 2.0 diagram in context of Holiday project



## Todo's
- Certification for https part must be generated
- https does not still include
- maybe Service Discovery (Eureka Server)
- Password encryption: https://www.codejava.net/frameworks/spring-boot/spring-boot-password-encryption
- Installation of yEd: https://www.yworks.com/products/yed/download

