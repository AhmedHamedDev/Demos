using Specification_Pattern;

var gRating = new MpaaRatingAtMostSpecification(MpaaRating.G);
bool isOk = gRating.IsSatisfiedBy(movie); // Exercising a single movie
IReadOnlyList<Movie> movies = repository.Find(gRating); // Getting a list of movies



var gRating = new MpaaRatingAtMostSpecification(MpaaRating.G);
var goodMovie = new GoodMovieSpecification();
var repository = new MovieRepository();

IReadOnlyList<Movie> movies = repository.Find(gRating.And(goodMovie));