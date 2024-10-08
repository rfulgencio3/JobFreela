﻿using MediatR;

namespace JobFreela.Application.Commands.UpdateProject;

public class UpdateProjectCommand : IRequest
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal TotalCost { get; set; }
}
