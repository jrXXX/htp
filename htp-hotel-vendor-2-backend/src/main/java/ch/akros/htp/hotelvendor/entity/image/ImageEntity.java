package ch.akros.htp.hotelvendor.entity.image;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.ForeignKey;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;
import javax.validation.constraints.NotBlank;
import javax.validation.constraints.Size;

import ch.akros.htp.hotelvendor.entity.hotel.HotelEntity;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import lombok.ToString;

@Entity
@Getter
@Setter
@Builder
@NoArgsConstructor
@AllArgsConstructor
@ToString
@Table(name = "image")
public class ImageEntity {
	@Id
	@Column(name = "id", nullable = false, unique = true)
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Long id;

	@NotBlank
	@Size(min = 3, max = 120)
	@Column(name = "NAME")
	private String name;

	@Column(name = "WIDTH")
	private int width;

	@Column(name = "HEIGHT")
	private int height;

	@Column(name = "DOWNLOAD_URL")
	private String downloadUrl;

	@ManyToOne
	@JoinColumn(referencedColumnName = "id", name = "hotel_id", foreignKey = @ForeignKey(name = "hotel_id_image_fk"))
	private HotelEntity hotel;
}
