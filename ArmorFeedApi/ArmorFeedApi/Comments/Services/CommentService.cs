using ArmorFeedApi.Comments.Domain.Models;
using ArmorFeedApi.Comments.Domain.Repositories;
using ArmorFeedApi.Comments.Domain.Services;
using ArmorFeedApi.Comments.Domain.Services.Communication;
using ArmorFeedApi.Customers.Domain.Repositories;
using ArmorFeedApi.Shared.Domain.Repositories;
using ArmorFeedApi.Shipments.Domain.Repositories;


namespace ArmorFeedApi.Comments.Services;

public class CommentService: ICommentService
{
    private readonly ICommentRepository _commentRepository;
       
        private readonly ICustomerRepository _customerRepository;
        private readonly IShipmentRepository _shipmentRepository;
        
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(ICommentRepository commentRepository, ICustomerRepository customerRepository,IShipmentRepository shipmentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            
            _customerRepository = customerRepository;
            _shipmentRepository = shipmentRepository;
            
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Comment>> ListAsync()
        {
            return await _commentRepository.ListAsync();
        }
        
        public async Task<IEnumerable<Comment>> ListByCustomerAsync(int customerId)
        {
            return await _commentRepository.FindByCustomerId(customerId);
        }
        public async Task<IEnumerable<Comment>> ListByShipmentAsync(int shipmentId)
        {
            return await _commentRepository.FindByShipmentId(shipmentId);
        }

        
        public async Task<Comment> FindByIdAsync(int id)
        {
            var comment = await _commentRepository.FindByIdAsync(id);
            return comment;
        }

        public async Task<CommentResponse> SaveAsync(Comment comment)
        {
            
            var existingCustomer = await _customerRepository.FindByIdAsync(comment.CustomerId);
            var existingShipment = await _shipmentRepository.FindByIdAsync(comment.ShipmentId);
            if (existingCustomer == null && existingShipment==null)
            {
                return new CommentResponse("Customer or Shipment not found.");
            }
            
            try
            {
                await _commentRepository.AddAsync(comment);
                await _unitOfWork.CompleteAsync();
                return new CommentResponse(comment);
            }
            catch (Exception e)
            {
                return new CommentResponse($"An error occurred while saving the comment: {e.Message}");
            }   
         
        }
        
        public async Task<CommentResponse> UpdateAsync(int id, Comment comment)
        {
            var existingComment = await _commentRepository.FindByIdAsync(id);
            if (existingComment == null)
            {
                return new CommentResponse("Comment not found");
            }

            existingComment.Title = comment.Title;
            existingComment.Content = comment.Content;
            try
            {
                _commentRepository.Update(existingComment);
                await _unitOfWork.CompleteAsync();
                return new CommentResponse(existingComment);
            }
            catch (Exception e)
            {
                return new CommentResponse($"An error occurred while updating the comment: {e.Message}");
            }
        }

        public async Task<CommentResponse> DeleteAsync(int id)
        {
            var existingComment = await _commentRepository.FindByIdAsync(id);
            if (existingComment == null)
            {
                return new CommentResponse("Comment not found");
            }

            try
            {
                _commentRepository.Remove(existingComment);
                await _unitOfWork.CompleteAsync();
                return new CommentResponse(existingComment);
            }
            catch (Exception e)
            {
                return new CommentResponse($"An error occurred while deleting the comment: {e.Message}");
            }
        }
}