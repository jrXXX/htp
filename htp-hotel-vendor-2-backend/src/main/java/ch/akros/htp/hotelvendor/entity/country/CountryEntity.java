package ch.akros.htp.hotelvendor.entity.country;

import java.util.List;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.validation.constraints.NotBlank;
import javax.validation.constraints.Size;

import ch.akros.htp.hotelvendor.entity.hotel.HotelEntity;
import lombok.AccessLevel;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import lombok.ToString;


@NoArgsConstructor
@AllArgsConstructor(access = AccessLevel.PRIVATE)
@Builder
@Entity
@Setter
@Getter
@ToString
@Table(name = "COUNTRY")
public class CountryEntity {

    @Id
    @Column(name = "id", nullable = false, unique = true)
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @NotBlank
    @Size(min = 3, max = 100)
    @Column(name = "NAME")
    private String name;

    @NotBlank
    @Size(max = 3)
    @Column(name = "CODE")
    private String code;

    @OneToMany(mappedBy = "country", cascade = CascadeType.ALL)
    private List<HotelEntity> hotels;
}
