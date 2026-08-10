using EducationalPlatform.Application.Features.Courses.Commands.CreateCourse;
using EducationalPlatform.Application.Features.Courses.Commands.DeleteCourse;
using EducationalPlatform.Application.Features.Courses.Commands.UpdateCourse;
using EducationalPlatform.Application.Interfaces;
using EducationalPlatform.Domain.Entities;
using EducationalPlatform.Domain.Enums;

namespace EducationalPlatform.Infrastructure.Services;

public class CourseService : ICourseService
{
    private readonly IRepository<Course> _courseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CourseService(
        IRepository<Course> courseRepository,
        IUnitOfWork unitOfWork)
    {
        _courseRepository = courseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateCourseResponse> CreateCourseAsync(
        CreateCourseCommand command)
    {
        var course = new Course
        {
            Title = command.Title,
            Slug = command.Slug,
            ShortDescription = command.ShortDescription,
            Description = command.Description,
            Price = command.Price,
            CategoryId = command.CategoryId,
            Difficulty = command.Difficulty,
            DeliveryType = command.DeliveryType,
            Status = CourseStatus.Draft
        };

        await _courseRepository.AddAsync(course);

        await _unitOfWork.SaveChangesAsync();

        return new CreateCourseResponse
        {
            Succeeded = true,
            Message = "Course created successfully.",
            CourseId = course.Id
        };
    }

    public async Task<IReadOnlyList<Course>> GetAllAsync()
    {
        return await _courseRepository.GetAllAsync();
    }

    public async Task<UpdateCourseResponse> UpdateCourseAsync(
        UpdateCourseCommand command)
    {
        var course = await _courseRepository.GetByIdAsync(command.Id);

        if (course is null)
        {
            return new UpdateCourseResponse
            {
                Succeeded = false,
                Message = "Course not found.",
                CourseId = command.Id
            };
        }

        course.Title = command.Title;
        course.Slug = command.Slug;
        course.ShortDescription = command.ShortDescription;
        course.Description = command.Description;
        course.Price = command.Price;
        course.CategoryId = command.CategoryId;
        course.Difficulty = command.Difficulty;
        course.DeliveryType = command.DeliveryType;

        _courseRepository.Update(course);

        await _unitOfWork.SaveChangesAsync();

        return new UpdateCourseResponse
        {
            Succeeded = true,
            Message = "Course updated successfully.",
            CourseId = course.Id
        };
    }

    public async Task<DeleteCourseResponse> DeleteCourseAsync(
        DeleteCourseCommand command)
    {
        var course = await _courseRepository.GetByIdAsync(command.Id);

        if (course is null)
        {
            return new DeleteCourseResponse
            {
                Succeeded = false,
                Message = "Course not found.",
                CourseId = command.Id
            };
        }

        _courseRepository.Delete(course);

        await _unitOfWork.SaveChangesAsync();

        return new DeleteCourseResponse
        {
            Succeeded = true,
            Message = "Course deleted successfully.",
            CourseId = course.Id
        };
    }
}