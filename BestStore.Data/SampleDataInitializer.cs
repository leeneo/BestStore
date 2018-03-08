using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BestStore.Models;

namespace BestStore.Data
{
    public class SampleDataInitializer
    {
        private BestStoreDbContext _dbContext = null;

        private readonly string _brandRootPath = "/Assets/Brands/";
        private readonly string _productRootPath = "/Assets/Products/";
        public SampleDataInitializer(BestStoreDbContext context)
        {
            _dbContext = context;
        }

        public async Task LoadSampleDataAsync()
        {
            // Add Categories
            _dbContext.Categories.Add(new Category { CategoryName = "健身器械" });
            _dbContext.Categories.Add(new Category { CategoryName = "健身补剂" });

            // Add Brands
            _dbContext.Brands.Add(new Brand
            {
                BrandName = "LifeFitness",
                Logo = BrandImagePath("Life-Fitness.jpg"),
                Description = "悠久历史，一脉相承；卓越的产品和设计，设立行业标准。最先进的人体工程学研究，世界领先的生产制造流程，各种最严格测试。对健身的专注和执着，与众不同的健身感受，健身房布局与力健之旅。健身专家及合作伙伴，脱颖而出，全球第一。美国500强公司（康体娱乐设备排名第一），美国上市公司宾士域集团全资附属子公司，全球高品质商用和家用设备设计和制造行业的领导者。自1968年开始，以高效耐用、使用简单等优点树立了行业标准，市场领导地位无可撼动。全球设有10个直属办公室（美国 / 加拿大 / 拉美，亚太地区，巴西，欧洲 / 中东 / 非洲，德国 / 瑞士，澳大利亚，意大利，日本，西班牙，英国） 产品销至120个国家，全球范围内市场占有率第一 "
            });
            _dbContext.Brands.Add(new Brand
            {
                BrandName = "MASSFIT",
                Logo = BrandImagePath("massfit.jpg"),
                Description = "MASSFIT（马西）是一个专业力量训练器材的著名品牌，产品汇集欧美澳三地的杰出产品，领先国内市场，不断为国内健身爱好者提供专业的、先进的、高品质的健身器材，并受到多方好评！此次马西旗舰店登录京东商城，将为MASSFIT（马西）品牌的健身器材开辟更加广阔的国内市场。"
            });
            _dbContext.Brands.Add(new Brand
            {
                BrandName = "MET-Rx(美瑞克斯)",
                Logo = BrandImagePath("MET-Rx.png"),
                Description = "上世纪70年代，波斯顿大学神经生理学教授、医学博士Scott Connelly 在研究神经与肌肉能力学，神经与肌肉营养性相互关系时，发现不同的蛋白矩阵对肌肉构成有影响，这引起了他极大的兴趣，经过20多年潜心研究，Connelly博士开发出美瑞克斯(MET-Rx®)产品的核心蛋白配方,Metamyosyn专利配方蛋白，这种蛋白通过为人体提供不同生理效用及特定比例的优质蛋白，帮助人体构建肌肉并减少体脂含量，这种产品一经问世立即得到了世界顶级运动员、好莱坞明星和众多健身爱好者的积极响应和高度评价。此后美瑞克斯(MET-Rx®) 相继推出几个系列的蛋白、氨基酸、燃脂等产品，被应用于专业运动员及普通大众健身过程中的力量、体形和耐力的训练。"
            });
            _dbContext.Brands.Add(new Brand
            {
                BrandName = "MuscleTech(肌肉科技)",
                Logo = BrandImagePath("MuscleTech.jpg"),
                Description = "肌肉科技（Muscletech）全球运动补剂的神话。全球最知名品牌之一，肌肉科技明星团队包括了乔卡特，菲尔·希斯，德克斯特·杰克逊等超级明星。肌肉科技产品无处不在，在美国任何一本健身杂志，每一场健美比赛，所有营养品专卖店，肌肉科技的标志都会矗立眼前。肌肉科技的追随者以几何速度每天增长。肌肉科技超级明星团队代表全球健美的辉煌，肌肉科技的竞争对手们也只能每天努力奋斗着甘居亚军，这就是肌肉科技文化。"
            });
            _dbContext.Brands.Add(new Brand
            {
                BrandName = "PROIRON",
                Logo = BrandImagePath("PROIRON.jpg"),
                Description = "PROIRON是一个由全球最大的举重类健身器材制造商和供应商山西新和健身器材公司注册的健身器品牌，以稳定优良的品质，合理的价格和完善的服务在全球市场树立了卓越的声誉。"
            });

            // Submit data into Database
            await _dbContext.SaveChangesAsync();

            // Get CategoryIds
            string tester = string.Empty;
            tester = "健身器械";
            int equipmentId = _dbContext.Categories.SingleOrDefault(e => e.CategoryName == tester).CategoryID;
            tester = "健身补剂";
            int supplementId = _dbContext.Categories.SingleOrDefault(e => e.CategoryName == tester).CategoryID;

            // Get BrandIds
            tester = "LifeFitness";
            int lifefitnessId = _dbContext.Brands.SingleOrDefault(b => b.BrandName == tester).BrandID;
            tester = "MASSFIT";
            int massfitId = _dbContext.Brands.SingleOrDefault(b => b.BrandName == tester).BrandID;
            tester = "MET-Rx(美瑞克斯)";
            int metrxId = _dbContext.Brands.SingleOrDefault(b => b.BrandName == tester).BrandID;
            tester = "MuscleTech(肌肉科技)";
            int muscletechId = _dbContext.Brands.SingleOrDefault(b => b.BrandName == tester).BrandID;
            tester = "PROIRON";
            int proironId = _dbContext.Brands.SingleOrDefault(b => b.BrandName == tester).BrandID;

            // Add Products
            _dbContext.Products.Add(new Product
            {
                ProductID = new Guid("5A187D13-3023-4A8B-4448-08D371929CF9"),
                ProductName = "美国力健家用静音健身车",
                BrandID = lifefitnessId,
                CategoryID = equipmentId,
                Description = "人性化设计，走越式设计家辅助扶手方便用户上、下机。多种座椅调节方式确保不同提醒的人群可以体验到舒适、自然的训练。",
                ThumbnailImage = ProductThumbImagePath("5A187D13-3023-4A8B-4448-08D371929CF9", "1.jpg"),
                Length = 124.50f,
                Width = 23.40f,
                Height = 113.00f,
                UnitofLength = "cm",
                Weight = 52.8f,
                UnitofWeight = "kg",
                UnitPrice = 30660.00f,
                Currency = "RMB"
            });

            _dbContext.ProductImages.AddRange(new ProductImage[] {
                new ProductImage {
                    ProductID = new Guid ("5A187D13-3023-4A8B-4448-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("5A187D13-3023-4A8B-4448-08D371929CF9", "1.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("5A187D13-3023-4A8B-4448-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("5A187D13-3023-4A8B-4448-08D371929CF9", "2.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("5A187D13-3023-4A8B-4448-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("5A187D13-3023-4A8B-4448-08D371929CF9", "3.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("5A187D13-3023-4A8B-4448-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("5A187D13-3023-4A8B-4448-08D371929CF9", "4.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("5A187D13-3023-4A8B-4448-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("5A187D13-3023-4A8B-4448-08D371929CF9", "5.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("5A187D13-3023-4A8B-4448-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("5A187D13-3023-4A8B-4448-08D371929CF9", "6.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("5A187D13-3023-4A8B-4448-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("5A187D13-3023-4A8B-4448-08D371929CF9", "7.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("5A187D13-3023-4A8B-4448-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("5A187D13-3023-4A8B-4448-08D371929CF9", "8.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("5A187D13-3023-4A8B-4448-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("5A187D13-3023-4A8B-4448-08D371929CF9", "9.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("5A187D13-3023-4A8B-4448-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("5A187D13-3023-4A8B-4448-08D371929CF9", "10.jpg")
                }
            });
            await _dbContext.SaveChangesAsync();

            _dbContext.Products.Add(new Product
            {
                ProductID = new Guid("9ED6C85F-F379-448B-4449-08D371929CF9"),
                ProductName = "美国Life Fitness力健多功能综合训练小飞鸟家用肌肉力量健身器G7",
                BrandID = lifefitnessId,
                CategoryID = equipmentId,
                Description = "力健力量设备借鉴了Hammer豪迈力量系列的创新特色，豪迈品牌是高级健身俱乐部和专业运动员必选的力量训练设备。",
                ThumbnailImage = ProductThumbImagePath("9ED6C85F-F379-448B-4449-08D371929CF9", "1.jpg"),
                Length = 124.50f,
                Width = 89.40f,
                Height = 193.00f,
                UnitofLength = "cm",
                Weight = 98.8f,
                UnitofWeight = "kg",
                UnitPrice = 46170.00f,
                Currency = "RMB"
            });

            _dbContext.ProductImages.AddRange(new ProductImage[] {
                new ProductImage {
                    ProductID = new Guid ("9ED6C85F-F379-448B-4449-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("9ED6C85F-F379-448B-4449-08D371929CF9", "1.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("9ED6C85F-F379-448B-4449-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("9ED6C85F-F379-448B-4449-08D371929CF9", "2.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("9ED6C85F-F379-448B-4449-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("9ED6C85F-F379-448B-4449-08D371929CF9", "3.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("9ED6C85F-F379-448B-4449-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("9ED6C85F-F379-448B-4449-08D371929CF9", "4.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("9ED6C85F-F379-448B-4449-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("9ED6C85F-F379-448B-4449-08D371929CF9", "5.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("9ED6C85F-F379-448B-4449-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("9ED6C85F-F379-448B-4449-08D371929CF9", "6.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("9ED6C85F-F379-448B-4449-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("9ED6C85F-F379-448B-4449-08D371929CF9", "7.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("9ED6C85F-F379-448B-4449-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("9ED6C85F-F379-448B-4449-08D371929CF9", "8.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("9ED6C85F-F379-448B-4449-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("9ED6C85F-F379-448B-4449-08D371929CF9", "9.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("9ED6C85F-F379-448B-4449-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("9ED6C85F-F379-448B-4449-08D371929CF9", "10.jpg")
                }
            });
            await _dbContext.SaveChangesAsync();

            _dbContext.Products.Add(new Product
            {
                ProductID = new Guid("9FB5DDAE-41D2-4B62-444A-08D371929CF9"),
                ProductName = "美国Life Fitness力健力量健身综合训练器材家用多功能室内设备G4",
                BrandID = lifefitnessId,
                CategoryID = equipmentId,
                Description = "为了强化对下半身肌肉群的训练，用户可以选配蹬腿机/小腿训练机进行训练。中滑轮设计方便用户完成腹部、手臂、肩部和胸部的动作训练。",
                ThumbnailImage = ProductThumbImagePath("9FB5DDAE-41D2-4B62-444A-08D371929CF9", "1.jpg"),
                Length = 124.50f,
                Width = 89.40f,
                Height = 193.00f,
                UnitofLength = "cm",
                Weight = 98.8f,
                UnitofWeight = "kg",
                UnitPrice = 43170.00f,
                Currency = "RMB"
            });
            _dbContext.ProductImages.AddRange(new ProductImage[] {
                new ProductImage {
                    ProductID = new Guid ("9FB5DDAE-41D2-4B62-444A-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("9FB5DDAE-41D2-4B62-444A-08D371929CF9", "1.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("9FB5DDAE-41D2-4B62-444A-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("9FB5DDAE-41D2-4B62-444A-08D371929CF9", "2.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("9FB5DDAE-41D2-4B62-444A-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("9FB5DDAE-41D2-4B62-444A-08D371929CF9", "3.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("9FB5DDAE-41D2-4B62-444A-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("9FB5DDAE-41D2-4B62-444A-08D371929CF9", "4.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("9FB5DDAE-41D2-4B62-444A-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("9FB5DDAE-41D2-4B62-444A-08D371929CF9", "5.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("9FB5DDAE-41D2-4B62-444A-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("9FB5DDAE-41D2-4B62-444A-08D371929CF9", "6.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("9FB5DDAE-41D2-4B62-444A-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("9FB5DDAE-41D2-4B62-444A-08D371929CF9", "7.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("9FB5DDAE-41D2-4B62-444A-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("9FB5DDAE-41D2-4B62-444A-08D371929CF9", "8.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("9FB5DDAE-41D2-4B62-444A-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("9FB5DDAE-41D2-4B62-444A-08D371929CF9", "9.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("9FB5DDAE-41D2-4B62-444A-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("9FB5DDAE-41D2-4B62-444A-08D371929CF9", "10.jpg")
                }
            });
            await _dbContext.SaveChangesAsync();

            _dbContext.Products.Add(new Product
            {
                ProductID = new Guid("81DE0364-0401-4F38-444B-08D371929CF9"),
                ProductName = "美国力健Life Fitness家用商用多功能跑步机T5",
                BrandID = lifefitnessId,
                CategoryID = equipmentId,
                Description = "超静音，液晶触摸屏幕。",
                ThumbnailImage = ProductThumbImagePath("81DE0364-0401-4F38-444B-08D371929CF9", "1.jpg"),
                Length = 124.50f,
                Width = 89.40f,
                Height = 193.00f,
                UnitofLength = "cm",
                Weight = 98.8f,
                UnitofWeight = "kg",
                UnitPrice = 56000.00f,
                Currency = "RMB"
            });
            _dbContext.ProductImages.AddRange(new ProductImage[] {
                new ProductImage {
                    ProductID = new Guid ("81DE0364-0401-4F38-444B-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("81DE0364-0401-4F38-444B-08D371929CF9", "1.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("81DE0364-0401-4F38-444B-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("81DE0364-0401-4F38-444B-08D371929CF9", "2.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("81DE0364-0401-4F38-444B-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("81DE0364-0401-4F38-444B-08D371929CF9", "3.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("81DE0364-0401-4F38-444B-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("81DE0364-0401-4F38-444B-08D371929CF9", "4.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("81DE0364-0401-4F38-444B-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("81DE0364-0401-4F38-444B-08D371929CF9", "5.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("81DE0364-0401-4F38-444B-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("81DE0364-0401-4F38-444B-08D371929CF9", "6.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("81DE0364-0401-4F38-444B-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("81DE0364-0401-4F38-444B-08D371929CF9", "7.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("81DE0364-0401-4F38-444B-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("81DE0364-0401-4F38-444B-08D371929CF9", "8.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("81DE0364-0401-4F38-444B-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("81DE0364-0401-4F38-444B-08D371929CF9", "9.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("81DE0364-0401-4F38-444B-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("81DE0364-0401-4F38-444B-08D371929CF9", "10.jpg")
                }
            });
            await _dbContext.SaveChangesAsync();

            _dbContext.Products.Add(new Product
            {
                ProductID = new Guid("42FE79E8-FA1D-42AE-444C-08D371929CF9"),
                ProductName = "肌肉科技白金乳清蛋白粉5磅",
                BrandID = muscletechId,
                CategoryID = supplementId,
                Description = "乳清蛋白可以被身体快速吸收，易于消化，是训练后修复肌肉的优选。",
                ThumbnailImage = ProductThumbImagePath("42FE79E8-FA1D-42AE-444C-08D371929CF9", "1.jpg"),
                Length = 124.50f,
                Width = 89.40f,
                Height = 193.00f,
                UnitofLength = "cm",
                Weight = 2485f,
                UnitofWeight = "g",
                UnitPrice = 558.00f,
                Currency = "RMB"
            });
            _dbContext.ProductImages.AddRange(new ProductImage[] {
                new ProductImage {
                    ProductID = new Guid ("42FE79E8-FA1D-42AE-444C-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("42FE79E8-FA1D-42AE-444C-08D371929CF9", "1.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("42FE79E8-FA1D-42AE-444C-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("42FE79E8-FA1D-42AE-444C-08D371929CF9", "2.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("42FE79E8-FA1D-42AE-444C-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("42FE79E8-FA1D-42AE-444C-08D371929CF9", "3.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("42FE79E8-FA1D-42AE-444C-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("42FE79E8-FA1D-42AE-444C-08D371929CF9", "4.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("42FE79E8-FA1D-42AE-444C-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("42FE79E8-FA1D-42AE-444C-08D371929CF9", "5.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("42FE79E8-FA1D-42AE-444C-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("42FE79E8-FA1D-42AE-444C-08D371929CF9", "6.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("42FE79E8-FA1D-42AE-444C-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("42FE79E8-FA1D-42AE-444C-08D371929CF9", "7.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("42FE79E8-FA1D-42AE-444C-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("42FE79E8-FA1D-42AE-444C-08D371929CF9", "8.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("42FE79E8-FA1D-42AE-444C-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("42FE79E8-FA1D-42AE-444C-08D371929CF9", "9.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("42FE79E8-FA1D-42AE-444C-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("42FE79E8-FA1D-42AE-444C-08D371929CF9", "10.jpg")
                }
            });
            await _dbContext.SaveChangesAsync();

            _dbContext.Products.Add(new Product
            {
                ProductID = new Guid("178A79A4-F8DF-4FD9-444D-08D371929CF9"),
                ProductName = "肌肉科技复合蛋白粉健身增健肌粉7磅",
                BrandID = muscletechId,
                CategoryID = supplementId,
                Description = "超纯度乳清分离蛋白及多肽，最先进的错流细微过滤生产工艺。通过冷冻技术，保留丰富的蛋白质生物活性剂吸收率。每份含5.4可支链氨基酸和11.6克必需氨基酸",
                ThumbnailImage = ProductThumbImagePath("178A79A4-F8DF-4FD9-444D-08D371929CF9", "1.jpg"),
                Length = 124.50f,
                Width = 89.40f,
                Height = 193.00f,
                UnitofLength = "cm",
                Weight = 2485f,
                UnitofWeight = "g",
                UnitPrice = 558.00f,
                Currency = "RMB"
            });
            _dbContext.ProductImages.AddRange(new ProductImage[] {
                new ProductImage {
                    ProductID = new Guid ("178A79A4-F8DF-4FD9-444D-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("178A79A4-F8DF-4FD9-444D-08D371929CF9", "1.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("178A79A4-F8DF-4FD9-444D-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("178A79A4-F8DF-4FD9-444D-08D371929CF9", "2.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("178A79A4-F8DF-4FD9-444D-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("178A79A4-F8DF-4FD9-444D-08D371929CF9", "3.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("178A79A4-F8DF-4FD9-444D-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("178A79A4-F8DF-4FD9-444D-08D371929CF9", "4.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("178A79A4-F8DF-4FD9-444D-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("178A79A4-F8DF-4FD9-444D-08D371929CF9", "5.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("178A79A4-F8DF-4FD9-444D-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("178A79A4-F8DF-4FD9-444D-08D371929CF9", "6.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("178A79A4-F8DF-4FD9-444D-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("178A79A4-F8DF-4FD9-444D-08D371929CF9", "7.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("178A79A4-F8DF-4FD9-444D-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("178A79A4-F8DF-4FD9-444D-08D371929CF9", "8.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("178A79A4-F8DF-4FD9-444D-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("178A79A4-F8DF-4FD9-444D-08D371929CF9", "9.jpg")
                },
                new ProductImage {
                    ProductID = new Guid ("178A79A4-F8DF-4FD9-444D-08D371929CF9"),
                        RelativeUrl = ProductDetailImagePath ("178A79A4-F8DF-4FD9-444D-08D371929CF9", "10.jpg")
                }
            });
            await _dbContext.SaveChangesAsync();
        }
        public async Task LoadBasicInformationAsync()
        {
            // Add provinces
            _dbContext.Provinces.AddRange(
                new Province[] {
                    new Province { ProvinceName = "北京市" },
                    new Province { ProvinceName = "天津市" },
                    new Province { ProvinceName = "上海市" },
                    new Province { ProvinceName = "重庆市" },
                    new Province { ProvinceName = "河北省" },
                    new Province { ProvinceName = "山西省" },
                    new Province { ProvinceName = "台湾省" },
                    new Province { ProvinceName = "辽宁省" },
                    new Province { ProvinceName = "吉林省" },
                    new Province { ProvinceName = "黑龙江省" },
                    new Province { ProvinceName = "江苏省" },
                    new Province { ProvinceName = "浙江省" },
                    new Province { ProvinceName = "安徽省" },
                    new Province { ProvinceName = "福建省" },
                    new Province { ProvinceName = "江西省" },
                    new Province { ProvinceName = "山东省" },
                    new Province { ProvinceName = "河南省" },
                    new Province { ProvinceName = "湖北省" },
                    new Province { ProvinceName = "湖南省" },
                    new Province { ProvinceName = "广东省" },
                    new Province { ProvinceName = "甘肃省" },
                    new Province { ProvinceName = "四川省" },
                    new Province { ProvinceName = "贵州省" },
                    new Province { ProvinceName = "海南省" },
                    new Province { ProvinceName = "云南省" },
                    new Province { ProvinceName = "青海省" },
                    new Province { ProvinceName = "陕西省" },
                    new Province { ProvinceName = "广西壮族自治区" },
                    new Province { ProvinceName = "西藏自治区" },
                    new Province { ProvinceName = "宁夏回族自治区" },
                    new Province { ProvinceName = "新疆维吾尔自治区" },
                    new Province { ProvinceName = "内蒙古自治区" },
                    new Province { ProvinceName = "澳门特别行政区" },
                    new Province { ProvinceName = "香港特别行政区" },
                });
            await _dbContext.SaveChangesAsync();

            // add cities
            _dbContext.Cities.AddRange(
                new City[] {
                    new City { CityIndex = 1, ProvinceID = 1, CityName = "北京市" },
                    new City { CityIndex = 1, ProvinceID = 2, CityName = "天津市" },
                    new City { CityIndex = 1, ProvinceID = 3, CityName = "上海市" },
                    new City { CityIndex = 1, ProvinceID = 4, CityName = "重庆市" },
                    new City { CityIndex = 1, ProvinceID = 5, CityName = "石家庄市" },
                    new City { CityIndex = 2, ProvinceID = 5, CityName = "唐山市" },
                    new City { CityIndex = 3, ProvinceID = 5, CityName = "秦皇岛市" },
                    new City { CityIndex = 4, ProvinceID = 5, CityName = "邯郸市" },
                    new City { CityIndex = 5, ProvinceID = 5, CityName = "邢台市" },
                    new City { CityIndex = 6, ProvinceID = 5, CityName = "保定市" },
                    new City { CityIndex = 7, ProvinceID = 5, CityName = "张家口市" },
                    new City { CityIndex = 8, ProvinceID = 5, CityName = "承德市" },
                    new City { CityIndex = 9, ProvinceID = 5, CityName = "沧州市" },
                    new City { CityIndex = 10,ProvinceID = 5, CityName = "廊坊市" },
                    new City { CityIndex = 11,ProvinceID = 5, CityName = "衡水市" },
                    new City { CityIndex = 1, ProvinceID = 6, CityName = "太原市" },
                    new City { CityIndex = 2, ProvinceID = 6, CityName = "大同市" },
                    new City { CityIndex = 3, ProvinceID = 6, CityName = "阳泉市" },
                    new City { CityIndex = 4, ProvinceID = 6, CityName = "长治市" },
                    new City { CityIndex = 5, ProvinceID = 6, CityName = "晋城市" },
                    new City { CityIndex = 6, ProvinceID = 6, CityName = "朔州市" },
                    new City { CityIndex = 7, ProvinceID = 6, CityName = "晋中市" },
                    new City { CityIndex = 8, ProvinceID = 6, CityName = "运城市" },
                    new City { CityIndex = 9, ProvinceID = 6, CityName = "忻州市" },
                    new City { CityIndex = 10,ProvinceID = 6, CityName = "临汾市" },
                    new City { CityIndex = 11,ProvinceID = 6, CityName = "吕梁市" },
                    new City { CityIndex = 1, ProvinceID = 7, CityName = "台北市" },
                    new City { CityIndex = 2, ProvinceID = 7, CityName = "高雄市" },
                    new City { CityIndex = 3, ProvinceID = 7, CityName = "基隆市" },
                    new City { CityIndex = 4, ProvinceID = 7, CityName = "台中市" },
                    new City { CityIndex = 5, ProvinceID = 7, CityName = "台南市" },
                    new City { CityIndex = 6, ProvinceID = 7, CityName = "新竹市" },
                    new City { CityIndex = 7, ProvinceID = 7, CityName = "嘉义市" },
                    new City { CityIndex = 8, ProvinceID = 7, CityName = "台北县" },
                    new City { CityIndex = 9, ProvinceID = 7, CityName = "宜兰县" },
                    new City { CityIndex = 10,ProvinceID = 7, CityName = "桃园县" },
                    new City { CityIndex = 11,ProvinceID = 7, CityName = "新竹县" },
                    new City { CityIndex = 12,ProvinceID = 7, CityName = "苗栗县" },
                    new City { CityIndex = 13,ProvinceID = 7, CityName = "台中县" },
                    new City { CityIndex = 14,ProvinceID = 7, CityName = "彰化县" },
                    new City { CityIndex = 15,ProvinceID = 7, CityName = "南投县" },
                    new City { CityIndex = 16,ProvinceID = 7, CityName = "云林县" },
                    new City { CityIndex = 17,ProvinceID = 7, CityName = "嘉义县" },
                    new City { CityIndex = 18,ProvinceID = 7, CityName = "台南县" },
                    new City { CityIndex = 19,ProvinceID = 7, CityName = "高雄县" },
                    new City { CityIndex = 20,ProvinceID = 7, CityName = "屏东县" },
                    new City { CityIndex = 21,ProvinceID = 7, CityName = "澎湖县" },
                    new City { CityIndex = 22,ProvinceID = 7, CityName = "台东县" },
                    new City { CityIndex = 23,ProvinceID = 7, CityName = "花莲县" },
                    new City { CityIndex = 1, ProvinceID = 8, CityName = "沈阳市" },
                    new City { CityIndex = 2, ProvinceID = 8, CityName = "大连市" },
                    new City { CityIndex = 3, ProvinceID = 8, CityName = "鞍山市" },
                    new City { CityIndex = 4, ProvinceID = 8, CityName = "抚顺市" },
                    new City { CityIndex = 5, ProvinceID = 8, CityName = "本溪市" },
                    new City { CityIndex = 6, ProvinceID = 8, CityName = "丹东市" },
                    new City { CityIndex = 7, ProvinceID = 8, CityName = "锦州市" },
                    new City { CityIndex = 8, ProvinceID = 8, CityName = "营口市" },
                    new City { CityIndex = 9, ProvinceID = 8, CityName = "阜新市" },
                    new City { CityIndex = 10,ProvinceID = 8, CityName = "辽阳市" },
                    new City { CityIndex = 11,ProvinceID = 8, CityName = "盘锦市" },
                    new City { CityIndex = 12,ProvinceID = 8, CityName = "铁岭市" },
                    new City { CityIndex = 13,ProvinceID = 8, CityName = "朝阳市" },
                    new City { CityIndex = 14,ProvinceID = 8, CityName = "葫芦岛市" },
                    new City { CityIndex = 1, ProvinceID = 9, CityName = "长春市" },
                    new City { CityIndex = 2, ProvinceID = 9, CityName = "吉林市" },
                    new City { CityIndex = 3, ProvinceID = 9, CityName = "四平市" },
                    new City { CityIndex = 4, ProvinceID = 9, CityName = "辽源市" },
                    new City { CityIndex = 5, ProvinceID = 9, CityName = "通化市" },
                    new City { CityIndex = 6, ProvinceID = 9, CityName = "白山市" },
                    new City { CityIndex = 7, ProvinceID = 9, CityName = "松原市" },
                    new City { CityIndex = 8, ProvinceID = 9, CityName = "白城市" },
                    new City { CityIndex = 9, ProvinceID = 9, CityName = "延边朝鲜族自治州" },
                    new City { CityIndex = 1, ProvinceID = 10,CityName = "哈尔滨市" },
                    new City { CityIndex = 2, ProvinceID = 10,CityName = "齐齐哈尔市" },
                    new City { CityIndex = 3, ProvinceID = 10,CityName = "鹤岗市" },
                    new City { CityIndex = 4, ProvinceID = 10,CityName = "双鸭山市" },
                    new City { CityIndex = 5, ProvinceID = 10,CityName = "鸡西市" },
                    new City { CityIndex = 6, ProvinceID = 10,CityName = "大庆市" },
                    new City { CityIndex = 7, ProvinceID = 10,CityName = "伊春市" },
                    new City { CityIndex = 8, ProvinceID = 10,CityName = "牡丹江市" },
                    new City { CityIndex = 9, ProvinceID = 10,CityName = "佳木斯市" },
                    new City { CityIndex = 10,ProvinceID = 10,CityName = "七台河市" },
                    new City { CityIndex = 11,ProvinceID = 10,CityName = "黑河市" },
                    new City { CityIndex = 12,ProvinceID = 10,CityName = "绥化市" },
                    new City { CityIndex = 13,ProvinceID = 10,CityName = "大兴安岭地区" },
                    new City { CityIndex = 1, ProvinceID = 11,CityName = "南京市" },
                    new City { CityIndex = 2, ProvinceID = 11,CityName = "无锡市" },
                    new City { CityIndex = 3, ProvinceID = 11,CityName = "徐州市" },
                    new City { CityIndex = 4, ProvinceID = 11,CityName = "常州市" },
                    new City { CityIndex = 5, ProvinceID = 11,CityName = "苏州市" },
                    new City { CityIndex = 6, ProvinceID = 11,CityName = "南通市" },
                    new City { CityIndex = 7, ProvinceID = 11,CityName = "连云港市" },
                    new City { CityIndex = 8, ProvinceID = 11,CityName = "淮安市" },
                    new City { CityIndex = 9, ProvinceID = 11,CityName = "盐城市" },
                    new City { CityIndex = 10,ProvinceID = 11,CityName = "扬州市" },
                    new City { CityIndex = 11,ProvinceID = 11,CityName = "镇江市" },
                    new City { CityIndex = 12,ProvinceID = 11,CityName = "泰州市" },
                    new City { CityIndex = 13,ProvinceID = 11,CityName = "宿迁市" },
                    new City { CityIndex = 1, ProvinceID = 12,CityName = "杭州市" },
                    new City { CityIndex = 2, ProvinceID = 12,CityName = "宁波市" },
                    new City { CityIndex = 3, ProvinceID = 12,CityName = "温州市" },
                    new City { CityIndex = 4, ProvinceID = 12,CityName = "嘉兴市" },
                    new City { CityIndex = 5, ProvinceID = 12,CityName = "湖州市" },
                    new City { CityIndex = 6, ProvinceID = 12,CityName = "绍兴市" },
                    new City { CityIndex = 7, ProvinceID = 12,CityName = "金华市" },
                    new City { CityIndex = 8, ProvinceID = 12,CityName = "衢州市" },
                    new City { CityIndex = 9, ProvinceID = 12,CityName = "舟山市" },
                    new City { CityIndex = 10,ProvinceID = 12,CityName = "台州市" },
                    new City { CityIndex = 11,ProvinceID = 12,CityName = "丽水市" },
                    new City { CityIndex = 1, ProvinceID = 13,CityName = "合肥市" },
                    new City { CityIndex = 2, ProvinceID = 13,CityName = "芜湖市" },
                    new City { CityIndex = 3, ProvinceID = 13,CityName = "蚌埠市" },
                    new City { CityIndex = 4, ProvinceID = 13,CityName = "淮南市" },
                    new City { CityIndex = 5, ProvinceID = 13,CityName = "马鞍山市" },
                    new City { CityIndex = 6, ProvinceID = 13,CityName = "淮北市" },
                    new City { CityIndex = 7, ProvinceID = 13,CityName = "铜陵市" },
                    new City { CityIndex = 8, ProvinceID = 13,CityName = "安庆市" },
                    new City { CityIndex = 9, ProvinceID = 13,CityName = "黄山市" },
                    new City { CityIndex = 10,ProvinceID = 13,CityName = "滁州市" },
                    new City { CityIndex = 11,ProvinceID = 13,CityName = "阜阳市" },
                    new City { CityIndex = 12,ProvinceID = 13,CityName = "宿州市" },
                    new City { CityIndex = 13,ProvinceID = 13,CityName = "巢湖市" },
                    new City { CityIndex = 14,ProvinceID = 13,CityName = "六安市" },
                    new City { CityIndex = 15,ProvinceID = 13,CityName = "亳州市" },
                    new City { CityIndex = 16,ProvinceID = 13,CityName = "池州市" },
                    new City { CityIndex = 17,ProvinceID = 13,CityName = "宣城市" },
                    new City { CityIndex = 1, ProvinceID = 14,CityName = "福州市" },
                    new City { CityIndex = 2, ProvinceID = 14,CityName = "厦门市" },
                    new City { CityIndex = 3, ProvinceID = 14,CityName = "莆田市" },
                    new City { CityIndex = 4, ProvinceID = 14,CityName = "三明市" },
                    new City { CityIndex = 5, ProvinceID = 14,CityName = "泉州市" },
                    new City { CityIndex = 6, ProvinceID = 14,CityName = "漳州市" },
                    new City { CityIndex = 7, ProvinceID = 14,CityName = "南平市" },
                    new City { CityIndex = 8, ProvinceID = 14,CityName = "龙岩市" },
                    new City { CityIndex = 9, ProvinceID = 14,CityName = "宁德市" },
                    new City { CityIndex = 1, ProvinceID = 15,CityName = "南昌市" },
                    new City { CityIndex = 2, ProvinceID = 15,CityName = "景德镇市" },
                    new City { CityIndex = 3, ProvinceID = 15,CityName = "萍乡市" },
                    new City { CityIndex = 4, ProvinceID = 15,CityName = "九江市" },
                    new City { CityIndex = 5, ProvinceID = 15,CityName = "新余市" },
                    new City { CityIndex = 6, ProvinceID = 15,CityName = "鹰潭市" },
                    new City { CityIndex = 7, ProvinceID = 15,CityName = "赣州市" },
                    new City { CityIndex = 8, ProvinceID = 15,CityName = "吉安市" },
                    new City { CityIndex = 9, ProvinceID = 15,CityName = "宜春市" },
                    new City { CityIndex = 10,ProvinceID = 15,CityName = "抚州市" },
                    new City { CityIndex = 11,ProvinceID = 15,CityName = "上饶市" },
                    new City { CityIndex = 1, ProvinceID = 16,CityName = "济南市" },
                    new City { CityIndex = 2, ProvinceID = 16,CityName = "青岛市" },
                    new City { CityIndex = 3, ProvinceID = 16,CityName = "淄博市" },
                    new City { CityIndex = 4, ProvinceID = 16,CityName = "枣庄市" },
                    new City { CityIndex = 5, ProvinceID = 16,CityName = "东营市" },
                    new City { CityIndex = 6, ProvinceID = 16,CityName = "烟台市" },
                    new City { CityIndex = 7, ProvinceID = 16,CityName = "潍坊市" },
                    new City { CityIndex = 8, ProvinceID = 16,CityName = "济宁市" },
                    new City { CityIndex = 9, ProvinceID = 16,CityName = "泰安市" },
                    new City { CityIndex = 10,ProvinceID = 16,CityName = "威海市" },
                    new City { CityIndex = 11,ProvinceID = 16,CityName = "日照市" },
                    new City { CityIndex = 12,ProvinceID = 16,CityName = "莱芜市" },
                    new City { CityIndex = 13,ProvinceID = 16,CityName = "临沂市" },
                    new City { CityIndex = 14,ProvinceID = 16,CityName = "德州市" },
                    new City { CityIndex = 15,ProvinceID = 16,CityName = "聊城市" },
                    new City { CityIndex = 16,ProvinceID = 16,CityName = "滨州市" },
                    new City { CityIndex = 17,ProvinceID = 16,CityName = "菏泽市" },
                    new City { CityIndex = 1, ProvinceID = 17,CityName = "郑州市" },
                    new City { CityIndex = 2, ProvinceID = 17,CityName = "开封市" },
                    new City { CityIndex = 3, ProvinceID = 17,CityName = "洛阳市" },
                    new City { CityIndex = 4, ProvinceID = 17,CityName = "平顶山市" },
                    new City { CityIndex = 5, ProvinceID = 17,CityName = "安阳市" },
                    new City { CityIndex = 6, ProvinceID = 17,CityName = "鹤壁市" },
                    new City { CityIndex = 7, ProvinceID = 17,CityName = "新乡市" },
                    new City { CityIndex = 8, ProvinceID = 17,CityName = "焦作市" },
                    new City { CityIndex = 9, ProvinceID = 17,CityName = "濮阳市" },
                    new City { CityIndex = 10,ProvinceID = 17,CityName = "许昌市" },
                    new City { CityIndex = 11,ProvinceID = 17,CityName = "漯河市" },
                    new City { CityIndex = 12,ProvinceID = 17,CityName = "三门峡市" },
                    new City { CityIndex = 13,ProvinceID = 17,CityName = "南阳市" },
                    new City { CityIndex = 14,ProvinceID = 17,CityName = "商丘市" },
                    new City { CityIndex = 15,ProvinceID = 17,CityName = "信阳市" },
                    new City { CityIndex = 16,ProvinceID = 17,CityName = "周口市" },
                    new City { CityIndex = 17,ProvinceID = 17,CityName = "驻马店市" },
                    new City { CityIndex = 18,ProvinceID = 17,CityName = "济源市" },
                    new City { CityIndex = 1, ProvinceID = 18,CityName = "武汉市" },
                    new City { CityIndex = 2, ProvinceID = 18,CityName = "黄石市" },
                    new City { CityIndex = 3, ProvinceID = 18,CityName = "十堰市" },
                    new City { CityIndex = 4, ProvinceID = 18,CityName = "荆州市" },
                    new City { CityIndex = 5, ProvinceID = 18,CityName = "宜昌市" },
                    new City { CityIndex = 6, ProvinceID = 18,CityName = "襄樊市" },
                    new City { CityIndex = 7, ProvinceID = 18,CityName = "鄂州市" },
                    new City { CityIndex = 8, ProvinceID = 18,CityName = "荆门市" },
                    new City { CityIndex = 9, ProvinceID = 18,CityName = "孝感市" },
                    new City { CityIndex = 10,ProvinceID = 18,CityName = "黄冈市" },
                    new City { CityIndex = 11,ProvinceID = 18,CityName = "咸宁市" },
                    new City { CityIndex = 12,ProvinceID = 18,CityName = "随州市" },
                    new City { CityIndex = 13,ProvinceID = 18,CityName = "仙桃市" },
                    new City { CityIndex = 14,ProvinceID = 18,CityName = "天门市" },
                    new City { CityIndex = 15,ProvinceID = 18,CityName = "潜江市" },
                    new City { CityIndex = 16,ProvinceID = 18,CityName = "神农架林区" },
                    new City { CityIndex = 17,ProvinceID = 18,CityName = "恩施土家族苗族自治州" },
                    new City { CityIndex = 1, ProvinceID = 19,CityName = "长沙市" },
                    new City { CityIndex = 2, ProvinceID = 19,CityName = "株洲市" },
                    new City { CityIndex = 3, ProvinceID = 19,CityName = "湘潭市" },
                    new City { CityIndex = 4, ProvinceID = 19,CityName = "衡阳市" },
                    new City { CityIndex = 5, ProvinceID = 19,CityName = "邵阳市" },
                    new City { CityIndex = 6, ProvinceID = 19,CityName = "岳阳市" },
                    new City { CityIndex = 7, ProvinceID = 19,CityName = "常德市" },
                    new City { CityIndex = 8, ProvinceID = 19,CityName = "张家界市" },
                    new City { CityIndex = 9, ProvinceID = 19,CityName = "益阳市" },
                    new City { CityIndex = 10,ProvinceID = 19,CityName = "郴州市" },
                    new City { CityIndex = 11,ProvinceID = 19,CityName = "永州市" },
                    new City { CityIndex = 12,ProvinceID = 19,CityName = "怀化市" },
                    new City { CityIndex = 13,ProvinceID = 19,CityName = "娄底市" },
                    new City { CityIndex = 14,ProvinceID = 19,CityName = "湘西土家族苗族自治州" },
                    new City { CityIndex = 1, ProvinceID = 20,CityName = "广州市" },
                    new City { CityIndex = 2, ProvinceID = 20,CityName = "深圳市" },
                    new City { CityIndex = 3, ProvinceID = 20,CityName = "珠海市" },
                    new City { CityIndex = 4, ProvinceID = 20,CityName = "汕头市" },
                    new City { CityIndex = 5, ProvinceID = 20,CityName = "韶关市" },
                    new City { CityIndex = 6, ProvinceID = 20,CityName = "佛山市" },
                    new City { CityIndex = 7, ProvinceID = 20,CityName = "江门市" },
                    new City { CityIndex = 8, ProvinceID = 20,CityName = "湛江市" },
                    new City { CityIndex = 9, ProvinceID = 20,CityName = "茂名市" },
                    new City { CityIndex = 10,ProvinceID = 20,CityName = "肇庆市" },
                    new City { CityIndex = 11,ProvinceID = 20,CityName = "惠州市" },
                    new City { CityIndex = 12,ProvinceID = 20,CityName = "梅州市" },
                    new City { CityIndex = 13,ProvinceID = 20,CityName = "汕尾市" },
                    new City { CityIndex = 14,ProvinceID = 20,CityName = "河源市" },
                    new City { CityIndex = 15,ProvinceID = 20,CityName = "阳江市" },
                    new City { CityIndex = 16,ProvinceID = 20,CityName = "清远市" },
                    new City { CityIndex = 17,ProvinceID = 20,CityName = "东莞市" },
                    new City { CityIndex = 18,ProvinceID = 20,CityName = "中山市" },
                    new City { CityIndex = 19,ProvinceID = 20,CityName = "潮州市" },
                    new City { CityIndex = 20,ProvinceID = 20,CityName = "揭阳市" },
                    new City { CityIndex = 21,ProvinceID = 20,CityName = "云浮市" },
                    new City { CityIndex = 1, ProvinceID = 21,CityName = "兰州市" },
                    new City { CityIndex = 2, ProvinceID = 21,CityName = "金昌市" },
                    new City { CityIndex = 3, ProvinceID = 21,CityName = "白银市" },
                    new City { CityIndex = 4, ProvinceID = 21,CityName = "天水市" },
                    new City { CityIndex = 5, ProvinceID = 21,CityName = "嘉峪关市" },
                    new City { CityIndex = 6, ProvinceID = 21,CityName = "武威市" },
                    new City { CityIndex = 7, ProvinceID = 21,CityName = "张掖市" },
                    new City { CityIndex = 8, ProvinceID = 21,CityName = "平凉市" },
                    new City { CityIndex = 9, ProvinceID = 21,CityName = "酒泉市" },
                    new City { CityIndex = 10,ProvinceID = 21,CityName = "庆阳市" },
                    new City { CityIndex = 11,ProvinceID = 21,CityName = "定西市" },
                    new City { CityIndex = 12,ProvinceID = 21,CityName = "陇南市" },
                    new City { CityIndex = 13,ProvinceID = 21,CityName = "临夏回族自治州" },
                    new City { CityIndex = 14,ProvinceID = 21,CityName = "甘南藏族自治州" },
                    new City { CityIndex = 1, ProvinceID = 22,CityName = "成都市" },
                    new City { CityIndex = 2, ProvinceID = 22,CityName = "自贡市" },
                    new City { CityIndex = 3, ProvinceID = 22,CityName = "攀枝花市" },
                    new City { CityIndex = 4, ProvinceID = 22,CityName = "泸州市" },
                    new City { CityIndex = 5, ProvinceID = 22,CityName = "德阳市" },
                    new City { CityIndex = 6, ProvinceID = 22,CityName = "绵阳市" },
                    new City { CityIndex = 7, ProvinceID = 22,CityName = "广元市" },
                    new City { CityIndex = 8, ProvinceID = 22,CityName = "遂宁市" },
                    new City { CityIndex = 9, ProvinceID = 22,CityName = "内江市" },
                    new City { CityIndex = 10,ProvinceID = 22,CityName = "乐山市" },
                    new City { CityIndex = 11,ProvinceID = 22,CityName = "南充市" },
                    new City { CityIndex = 12,ProvinceID = 22,CityName = "眉山市" },
                    new City { CityIndex = 13,ProvinceID = 22,CityName = "宜宾市" },
                    new City { CityIndex = 14,ProvinceID = 22,CityName = "广安市" },
                    new City { CityIndex = 15,ProvinceID = 22,CityName = "达州市" },
                    new City { CityIndex = 16,ProvinceID = 22,CityName = "雅安市" },
                    new City { CityIndex = 17,ProvinceID = 22,CityName = "巴中市" },
                    new City { CityIndex = 18,ProvinceID = 22,CityName = "资阳市" },
                    new City { CityIndex = 19,ProvinceID = 22,CityName = "阿坝藏族羌族自治州" },
                    new City { CityIndex = 20,ProvinceID = 22,CityName = "甘孜藏族自治州" },
                    new City { CityIndex = 21,ProvinceID = 22,CityName = "凉山彝族自治州" },
                    new City { CityIndex = 1, ProvinceID = 23,CityName = "贵阳市" },
                    new City { CityIndex = 2, ProvinceID = 23,CityName = "六盘水市" },
                    new City { CityIndex = 3, ProvinceID = 23,CityName = "遵义市" },
                    new City { CityIndex = 4, ProvinceID = 23,CityName = "安顺市" },
                    new City { CityIndex = 5, ProvinceID = 23,CityName = "铜仁地区" },
                    new City { CityIndex = 6, ProvinceID = 23,CityName = "毕节地区" },
                    new City { CityIndex = 7, ProvinceID = 23,CityName = "黔西南布依族苗族自治州" },
                    new City { CityIndex = 8, ProvinceID = 23,CityName = "黔东南苗族侗族自治州" },
                    new City { CityIndex = 9, ProvinceID = 23,CityName = "黔南布依族苗族自治州" },
                    new City { CityIndex = 1, ProvinceID = 24,CityName = "海口市" },
                    new City { CityIndex = 2, ProvinceID = 24,CityName = "三亚市" },
                    new City { CityIndex = 3, ProvinceID = 24,CityName = "五指山市" },
                    new City { CityIndex = 4, ProvinceID = 24,CityName = "琼海市" },
                    new City { CityIndex = 5, ProvinceID = 24,CityName = "儋州市" },
                    new City { CityIndex = 6, ProvinceID = 24,CityName = "文昌市" },
                    new City { CityIndex = 7, ProvinceID = 24,CityName = "万宁市" },
                    new City { CityIndex = 8, ProvinceID = 24,CityName = "东方市" },
                    new City { CityIndex = 9, ProvinceID = 24,CityName = "澄迈县" },
                    new City { CityIndex = 10,ProvinceID = 24,CityName = "定安县" },
                    new City { CityIndex = 11,ProvinceID = 24,CityName = "屯昌县" },
                    new City { CityIndex = 12,ProvinceID = 24,CityName = "临高县" },
                    new City { CityIndex = 13,ProvinceID = 24,CityName = "白沙黎族自治县" },
                    new City { CityIndex = 14,ProvinceID = 24,CityName = "昌江黎族自治县" },
                    new City { CityIndex = 15,ProvinceID = 24,CityName = "乐东黎族自治县" },
                    new City { CityIndex = 16,ProvinceID = 24,CityName = "陵水黎族自治县" },
                    new City { CityIndex = 17,ProvinceID = 24,CityName = "保亭黎族苗族自治县" },
                    new City { CityIndex = 18,ProvinceID = 24,CityName = "琼中黎族苗族自治县" },
                    new City { CityIndex = 1, ProvinceID = 25,CityName = "昆明市" },
                    new City { CityIndex = 2, ProvinceID = 25,CityName = "曲靖市" },
                    new City { CityIndex = 3, ProvinceID = 25,CityName = "玉溪市" },
                    new City { CityIndex = 4, ProvinceID = 25,CityName = "保山市" },
                    new City { CityIndex = 5, ProvinceID = 25,CityName = "昭通市" },
                    new City { CityIndex = 6, ProvinceID = 25,CityName = "丽江市" },
                    new City { CityIndex = 7, ProvinceID = 25,CityName = "思茅市" },
                    new City { CityIndex = 8, ProvinceID = 25,CityName = "临沧市" },
                    new City { CityIndex = 9, ProvinceID = 25,CityName = "文山壮族苗族自治州" },
                    new City { CityIndex = 10,ProvinceID = 25,CityName = "红河哈尼族彝族自治州" },
                    new City { CityIndex = 11,ProvinceID = 25,CityName = "西双版纳傣族自治州" },
                    new City { CityIndex = 12,ProvinceID = 25,CityName = "楚雄彝族自治州" },
                    new City { CityIndex = 13,ProvinceID = 25,CityName = "大理白族自治州" },
                    new City { CityIndex = 14,ProvinceID = 25,CityName = "德宏傣族景颇族自治州" },
                    new City { CityIndex = 15,ProvinceID = 25,CityName = "怒江傈傈族自治州" },
                    new City { CityIndex = 16,ProvinceID = 25,CityName = "迪庆藏族自治州" },
                    new City { CityIndex = 1, ProvinceID = 26,CityName = "西宁市" },
                    new City { CityIndex = 2, ProvinceID = 26,CityName = "海东地区" },
                    new City { CityIndex = 3, ProvinceID = 26,CityName = "海北藏族自治州" },
                    new City { CityIndex = 4, ProvinceID = 26,CityName = "黄南藏族自治州" },
                    new City { CityIndex = 5, ProvinceID = 26,CityName = "海南藏族自治州" },
                    new City { CityIndex = 6, ProvinceID = 26,CityName = "果洛藏族自治州" },
                    new City { CityIndex = 7, ProvinceID = 26,CityName = "玉树藏族自治州" },
                    new City { CityIndex = 8, ProvinceID = 26,CityName = "海西蒙古族藏族自治州" },
                    new City { CityIndex = 1, ProvinceID = 27,CityName = "西安市" },
                    new City { CityIndex = 2, ProvinceID = 27,CityName = "铜川市" },
                    new City { CityIndex = 3, ProvinceID = 27,CityName = "宝鸡市" },
                    new City { CityIndex = 4, ProvinceID = 27,CityName = "咸阳市" },
                    new City { CityIndex = 5, ProvinceID = 27,CityName = "渭南市" },
                    new City { CityIndex = 6, ProvinceID = 27,CityName = "延安市" },
                    new City { CityIndex = 7, ProvinceID = 27,CityName = "汉中市" },
                    new City { CityIndex = 8, ProvinceID = 27,CityName = "榆林市" },
                    new City { CityIndex = 9, ProvinceID = 27,CityName = "安康市" },
                    new City { CityIndex = 10,ProvinceID = 27,CityName = "商洛市" },
                    new City { CityIndex = 1, ProvinceID = 28,CityName = "南宁市" },
                    new City { CityIndex = 2, ProvinceID = 28,CityName = "柳州市" },
                    new City { CityIndex = 3, ProvinceID = 28,CityName = "桂林市" },
                    new City { CityIndex = 4, ProvinceID = 28,CityName = "梧州市" },
                    new City { CityIndex = 5, ProvinceID = 28,CityName = "北海市" },
                    new City { CityIndex = 6, ProvinceID = 28,CityName = "防城港市" },
                    new City { CityIndex = 7, ProvinceID = 28,CityName = "钦州市" },
                    new City { CityIndex = 8, ProvinceID = 28,CityName = "贵港市" },
                    new City { CityIndex = 9, ProvinceID = 28,CityName = "玉林市" },
                    new City { CityIndex = 10,ProvinceID = 28,CityName = "百色市" },
                    new City { CityIndex = 11,ProvinceID = 28,CityName = "贺州市" },
                    new City { CityIndex = 12,ProvinceID = 28,CityName = "河池市" },
                    new City { CityIndex = 13,ProvinceID = 28,CityName = "来宾市" },
                    new City { CityIndex = 14,ProvinceID = 28,CityName = "崇左市" },
                    new City { CityIndex = 1, ProvinceID = 29,CityName = "拉萨市" },
                    new City { CityIndex = 2, ProvinceID = 29,CityName = "那曲地区" },
                    new City { CityIndex = 3, ProvinceID = 29,CityName = "昌都地区" },
                    new City { CityIndex = 4, ProvinceID = 29,CityName = "山南地区" },
                    new City { CityIndex = 5, ProvinceID = 29,CityName = "日喀则地区" },
                    new City { CityIndex = 6, ProvinceID = 29,CityName = "阿里地区" },
                    new City { CityIndex = 7, ProvinceID = 29,CityName = "林芝地区" },
                    new City { CityIndex = 1, ProvinceID = 30,CityName = "银川市" },
                    new City { CityIndex = 2, ProvinceID = 30,CityName = "石嘴山市" },
                    new City { CityIndex = 3, ProvinceID = 30,CityName = "吴忠市" },
                    new City { CityIndex = 4, ProvinceID = 30,CityName = "固原市" },
                    new City { CityIndex = 5, ProvinceID = 30,CityName = "中卫市" },
                    new City { CityIndex = 1, ProvinceID = 31,CityName = "乌鲁木齐市" },
                    new City { CityIndex = 2, ProvinceID = 31,CityName = "克拉玛依市" },
                    new City { CityIndex = 3, ProvinceID = 31,CityName = "石河子市" },
                    new City { CityIndex = 4, ProvinceID = 31,CityName = "阿拉尔市" },
                    new City { CityIndex = 5, ProvinceID = 31,CityName = "图木舒克市" },
                    new City { CityIndex = 6, ProvinceID = 31,CityName = "五家渠市" },
                    new City { CityIndex = 7, ProvinceID = 31,CityName = "吐鲁番市" },
                    new City { CityIndex = 8, ProvinceID = 31,CityName = "阿克苏市" },
                    new City { CityIndex = 9, ProvinceID = 31,CityName = "喀什市" },
                    new City { CityIndex = 10,ProvinceID = 31,CityName = "哈密市" },
                    new City { CityIndex = 11,ProvinceID = 31,CityName = "和田市" },
                    new City { CityIndex = 12,ProvinceID = 31,CityName = "阿图什市" },
                    new City { CityIndex = 13,ProvinceID = 31,CityName = "库尔勒市" },
                    new City { CityIndex = 14,ProvinceID = 31,CityName = "昌吉市" },
                    new City { CityIndex = 15,ProvinceID = 31,CityName = "阜康市" },
                    new City { CityIndex = 16,ProvinceID = 31,CityName = "米泉市" },
                    new City { CityIndex = 17,ProvinceID = 31,CityName = "博乐市" },
                    new City { CityIndex = 18,ProvinceID = 31,CityName = "伊宁市" },
                    new City { CityIndex = 19,ProvinceID = 31,CityName = "奎屯市" },
                    new City { CityIndex = 20,ProvinceID = 31,CityName = "塔城市" },
                    new City { CityIndex = 21,ProvinceID = 31,CityName = "乌苏市" },
                    new City { CityIndex = 22,ProvinceID = 31,CityName = "阿勒泰市" },
                    new City { CityIndex = 1, ProvinceID = 32,CityName = "呼和浩特市" },
                    new City { CityIndex = 2, ProvinceID = 32,CityName = "包头市" },
                    new City { CityIndex = 3, ProvinceID = 32,CityName = "乌海市" },
                    new City { CityIndex = 4, ProvinceID = 32,CityName = "赤峰市" },
                    new City { CityIndex = 5, ProvinceID = 32,CityName = "通辽市" },
                    new City { CityIndex = 6, ProvinceID = 32,CityName = "鄂尔多斯市" },
                    new City { CityIndex = 7, ProvinceID = 32,CityName = "呼伦贝尔市" },
                    new City { CityIndex = 8, ProvinceID = 32,CityName = "巴彦淖尔市" },
                    new City { CityIndex = 9, ProvinceID = 32,CityName = "乌兰察布市" },
                    new City { CityIndex = 10,ProvinceID = 32,CityName = "锡林郭勒盟" },
                    new City { CityIndex = 11,ProvinceID = 32,CityName = "兴安盟" },
                    new City { CityIndex = 12,ProvinceID = 32,CityName = "阿拉善盟" },
                    new City { CityIndex = 1, ProvinceID = 33,CityName = "澳门特别行政区" },
                    new City { CityIndex = 1, ProvinceID = 34,CityName = "香港特别行政区" },
                });
            // Submit data into Database
            await _dbContext.SaveChangesAsync();
        }
        #region --- Private functions ---
        private string ProductThumbImagePath(Guid productID, string productImage)
        {
            return ProductThumbImagePath(productID.ToString("D").ToUpper(), productImage);
        }
        private string ProductThumbImagePath(string productID, string productImage)
        {
            return Path.Combine(_productRootPath, productID, productImage);
        }
        private string ProductDetailImagePath(Guid productID, string productImage)
        {
            return ProductDetailImagePath(productID.ToString("D").ToUpper(), productImage);
        }
        private string ProductDetailImagePath(string productID, string productImage)
        {
            return Path.Combine(_productRootPath, productID, "details", productImage).Replace("\\", "/");
        }
        private string BrandImagePath(string brandImage)
        {
            return Path.Combine(_brandRootPath, brandImage);
        }
        #endregion
    }
}