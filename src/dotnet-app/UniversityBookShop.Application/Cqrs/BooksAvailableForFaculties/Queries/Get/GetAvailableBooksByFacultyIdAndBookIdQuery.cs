using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Queries.Get;

public class GetAvailableBooksByFacultyIdAndBookIdQuery :
    IRequest<ServiceResult<BooksAvailableForFacultyDto>>
{
    public int FacultyId { get; set; }
    public int BookId { get; set; }

    public GetAvailableBooksByFacultyIdAndBookIdQuery(int facultyId, int bookId)
    {
        FacultyId = facultyId;
        BookId = bookId;
    }
}

public class GetAvailableBooksByFacultyIdAndBookIdQueryHandler :
    IRequestHandler<GetAvailableBooksByFacultyIdAndBookIdQuery,
        ServiceResult<BooksAvailableForFacultyDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetAvailableBooksByFacultyIdAndBookIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ServiceResult<BooksAvailableForFacultyDto>> Handle(
        GetAvailableBooksByFacultyIdAndBookIdQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.BooksAvailableForFaculties
            .AsNoTracking()
            .Where(x => x.FacultyId == request.FacultyId && x.BookId == request.BookId)
            .Include(x => x.Book)
                .ThenInclude(x => x!.CurrencyCode)
            .ProjectTo<BooksAvailableForFacultyDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException(nameof(BooksAvailableForFaculties), request.FacultyId, request.BookId);

        return ServiceResult.Success(query);
    }
}